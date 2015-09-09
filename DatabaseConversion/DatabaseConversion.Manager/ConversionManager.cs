using DatabaseConversion.Common.Configurations;
using DatabaseConversion.Common.Exceptions;
using DatabaseConversion.DatabaseAccess;
using DatabaseConversion.Manager.Generators;
using DatabaseConversion.Manager.MappingDefinitions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.Manager
{
    public class ConversionManager
    {
        private const string CONVERSION_PACKAGE_FOLDER = "Conversion";
        private const string BLOB_PACKAGE_FOLDER = "BLOB";
        private const string PRE_CONVERSION_PACKAGE_FOLDER = "PreConversion";
        private const string POST_CONVERSION_PACKAGE_FOLDER = "PostConversion";

        private string _packageOutputPath;
        private ConversionOption _options;
        private SourceDatabase _sourceDatabase;
        private DestinationDatabase _destinationDatabase;
        private BcpGenerator _bcpGenerator;

        public ConversionManager(string srcConnectionString, string destConnectionString, ConversionOption options)
        {
            _packageOutputPath = Path.Combine(ConfigurationManager.AppSettings["PackageOutputFolder"]);

            _options = options;

            _bcpGenerator = new BcpGenerator(options.ServerName, options.InstanceName);

            _sourceDatabase = new SourceDatabase(srcConnectionString);
            _sourceDatabase.Initialize();

            _destinationDatabase = new DestinationDatabase(destConnectionString);
            _destinationDatabase.Initialize();

            CreatePackageFolders();
        }

        public void GenerateConversionPackage()
        {
            GeneratePreConversionPackage();
            GenerateDataConversionPackage();
            GeneratePostConversionPackage();
        }

        #region Conversion Steps

        private void GeneratePreConversionPackage()
        {
            // TODO
        }

        private void GenerateDataConversionPackage()
        {
            List<string> scriptNames = new List<string>();
            Dictionary<string, string> bcpExportCommands = new Dictionary<string, string>();
            Dictionary<string, string> bcpImportCommands = new Dictionary<string, string>();

            _destinationDatabase.Tables.ForEach(t =>
            {
                DestinationTable destinationTable = t;
                SourceTable sourceTable = null;
                try
                {
                    Console.WriteLine("Processing " + destinationTable.Name);
                    TableMappingConfiguration mappingConfig = GetTableMappingConfig(destinationTable.Name);
                    sourceTable = GetSourceTable(destinationTable.Name, mappingConfig);
                    var mappingDefinition = CreateTableMappingDefinition(sourceTable, destinationTable, mappingConfig);
                    SqlGenerator sqlGenerator = new SqlGenerator(mappingDefinition);

                    HandleBcp(sqlGenerator, mappingDefinition, bcpExportCommands, bcpImportCommands);
                    HandleBlobUpdate(sqlGenerator, mappingDefinition, scriptNames);
                    HandleMaxTextUpdate(sqlGenerator, mappingDefinition, scriptNames);
                }
                catch (AppException ex)
                {
                    if (ex.ErrorCode == AppExceptionCodes.DATABASE_ERROR_TABLE_NOT_FOUND)
                    {
                        // TODO: write log
                        Console.WriteLine(destinationTable.Name + " not mapped");
                    }
                }
            });

            // Generate bat file
            string exportScript = BatGenerator.GenerateBcpExecuteBat(bcpExportCommands);
            SaveToFile(_packageOutputPath, "BCP_Export.bat", exportScript);
            Process.Start(new ProcessStartInfo { WorkingDirectory = _packageOutputPath, FileName = "BCP_Export.bat" });

            string importScript = BatGenerator.GenerateBcpExecuteBat(bcpImportCommands);
            SaveToFile(_packageOutputPath, "BCP_Import.bat", importScript);

            List<string> scriptPaths = scriptNames.Select(s => Path.Combine(CONVERSION_PACKAGE_FOLDER, s)).ToList();
            string updateScript = BatGenerator.GenerateSqlExecuteBat(scriptPaths, _options.ServerName, _options.InstanceName);
            SaveToFile(_packageOutputPath, "Update_Blob_Text.bat", updateScript);
        }

        private void GeneratePostConversionPackage()
        {
            // TODO
        }

        private void HandleBcp(SqlGenerator sqlGenerator, TableMappingDefinition mappingDefinition, Dictionary<string, string> bcpExportCommands, Dictionary<string, string> bcpImportCommands)
        {
            SourceTable srcTable = mappingDefinition.SourceTable;
            DestinationTable destTable = mappingDefinition.DestinationTable;
            string bcpPackagePath = Path.Combine(_packageOutputPath, CONVERSION_PACKAGE_FOLDER);

            // Generate and save format file
            string bcpExportFormatFile = _bcpGenerator.GenerateFormatFile(mappingDefinition, BcpDirection.Export);
            string exportFmtFileName = string.Format("{0}_EXPORT.fmt", destTable.Name);
            string exportFmtFilePath = Path.Combine(CONVERSION_PACKAGE_FOLDER, exportFmtFileName);
            SaveToFile(bcpPackagePath, exportFmtFileName, bcpExportFormatFile);

            string bcpImportFormatFile = _bcpGenerator.GenerateFormatFile(mappingDefinition, BcpDirection.Import);
            string importFmtFileName = string.Format("{0}_IMPORT.fmt", destTable.Name);
            string importFmtFilePath = Path.Combine(CONVERSION_PACKAGE_FOLDER, importFmtFileName);
            SaveToFile(bcpPackagePath, importFmtFileName, bcpImportFormatFile);
            
            // Generate export, import commands
            string bcpSelect = sqlGenerator.GenerateSelectStatement();
            string dataFileName = string.Format("{0}-{1}_BCP.txt", srcTable.Name, destTable.Name);
            string dataFilePath = Path.Combine(CONVERSION_PACKAGE_FOLDER, dataFileName);
            var bcpExportCommand = _bcpGenerator.GenerateExportCommand(destTable, bcpSelect, exportFmtFilePath, dataFilePath);
            bcpExportCommands.Add(dataFileName, bcpExportCommand);
            var bcpImportCommand = _bcpGenerator.GenerateImportCommand(destTable, importFmtFilePath, dataFilePath);
            bcpImportCommands.Add(dataFileName, bcpImportCommand);
        }

        private void HandleBlobUpdate(SqlGenerator sqlGenerator, TableMappingDefinition mappingDefinition, List<string> scriptNames)
        {
            SourceTable srcTable = mappingDefinition.SourceTable;
            DestinationTable destTable = mappingDefinition.DestinationTable;
            string postSqlPackagePath = Path.Combine(_packageOutputPath, CONVERSION_PACKAGE_FOLDER);

            string script = sqlGenerator.GenerateBlobFieldUpdateScript();
            if(!string.IsNullOrEmpty(script))
            {
                var fileName = string.Format("{0}-{1}_BLOB.sql", srcTable.Name, destTable.Name);
                SaveToFile(postSqlPackagePath, fileName, script);
                scriptNames.Add(fileName);
            }
        }

        private void HandleMaxTextUpdate(SqlGenerator sqlGenerator, TableMappingDefinition mappingDefinition, List<string> scriptNames)
        {
            SourceTable srcTable = mappingDefinition.SourceTable;
            DestinationTable destTable = mappingDefinition.DestinationTable;
            string postSqlPackagePath = Path.Combine(_packageOutputPath, CONVERSION_PACKAGE_FOLDER);

            string script = sqlGenerator.GenerateVarCharMaxUpdateScript();
            if(!string.IsNullOrEmpty(script))
            {
                var fileName = string.Format("{0}-{1}_TEXT.sql", srcTable.Name, destTable.Name);
                SaveToFile(postSqlPackagePath, fileName, script);
                scriptNames.Add(fileName);
            }
        }

        #endregion

        private TableMappingDefinition CreateTableMappingDefinition(SourceTable srcTable, DestinationTable destTable, TableMappingConfiguration mappingConfig)
        {
            TableMappingDefinition mappingDefinition;
            if (mappingConfig != null)
            {
                mappingDefinition = new TableMappingDefinition(srcTable, destTable, mappingConfig.FieldMappings);
                mappingDefinition.ExcludeExistData = mappingConfig.ExcludeExistData;
            }
            else
            {
                mappingDefinition = new TableMappingDefinition(srcTable, destTable);
            }

            return mappingDefinition;
        }

        private TableMappingConfiguration GetTableMappingConfig(string tableName)
        {
            return (_options != null && _options.ExplicitTableMappings != null)
                    ? _options.ExplicitTableMappings.SingleOrDefault(m => m.DestinationTableName.Equals(tableName, StringComparison.InvariantCultureIgnoreCase))
                    : null;
        }

        private SourceTable GetSourceTable(string destTableName, TableMappingConfiguration mappingConfig)
        {
            SourceTable sourceTable = null;
            if (mappingConfig != null)
            {
                string mapSourceTableName = mappingConfig.SourceTableName != null ? mappingConfig.SourceTableName : destTableName;
                sourceTable = _sourceDatabase.GetTable(mapSourceTableName);
            }
            else
            {
                sourceTable = _sourceDatabase.GetTable(destTableName);
            }


            return sourceTable;
        }

        private void CreatePackageFolders()
        {
            if(Directory.Exists(_packageOutputPath))
            {
                Directory.Delete(_packageOutputPath, true);
            }

            Directory.CreateDirectory(Path.Combine(_packageOutputPath, CONVERSION_PACKAGE_FOLDER));
            Directory.CreateDirectory(Path.Combine(_packageOutputPath, BLOB_PACKAGE_FOLDER));
            Directory.CreateDirectory(Path.Combine(_packageOutputPath, PRE_CONVERSION_PACKAGE_FOLDER));
            Directory.CreateDirectory(Path.Combine(_packageOutputPath, POST_CONVERSION_PACKAGE_FOLDER));
        }

        private void SaveToFile(string location, string fileName, string content)
        {
            string filePath = Path.Combine(location, fileName);

            FileInfo file = new FileInfo(filePath);
            file.Directory.Create();
            File.WriteAllText(file.FullName, content);
        }
    }
}
