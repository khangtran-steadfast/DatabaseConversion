using DatabaseConversion.CleanerTool.Executive;
using DatabaseConversion.Common;
using DatabaseConversion.Common.Configurations;
using DatabaseConversion.Common.Exceptions;
using DatabaseConversion.DatabaseAccess;
using DatabaseConversion.Manager.Constants;
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
        private const string POST_CONVERSION_PACKAGE_FOLDER = "PostConversion";

        private string _packageOutputPath;
        private ConversionOption _options;
        private SourceDatabase _sourceDatabase;
        private DestinationDatabase _destinationDatabase;
        private List<string> _listPreConversionScript = new List<string>();
        private List<string> _listPostConversionScript = new List<string>();

        public ConversionManager(string srcConnectionString, string destConnectionString, ConversionOption options)
        {
            _packageOutputPath = Path.Combine(ConfigurationManager.AppSettings["PackageOutputFolder"]);
            _options = options;

            _destinationDatabase = new DestinationDatabase(destConnectionString);
            _destinationDatabase.Initialize();
            _sourceDatabase = new SourceDatabase(srcConnectionString);
            _sourceDatabase.Initialize();
            _sourceDatabase.LearnPrimaryKeys(_destinationDatabase, options.ExplicitTableMappings);
            

            CreatePackageFolders();
        }

        public void Run()
        {
            if(_options.DoPreConversion)
            {
                DoPreConversion();
            }
            
            string conversionScript = DoConversion();
            string postScript = DoPostConversion();
            string clearLogScript = string.Format(BatTemplates.DELETE_FILE, "SQL_LOG.txt") + Environment.NewLine + string.Format(BatTemplates.DELETE_FILE, "BCP_LOG.txt");
            string finalScript = clearLogScript + Environment.NewLine + conversionScript + Environment.NewLine + postScript;
            SaveToFile(_packageOutputPath, "Run_Conversion.bat", finalScript);
        }

        #region Conversion Steps

        private void DoPreConversion()
        {
            Logger.Info("Doing pre-conversion job");

            Cleaner.CleanSourceDatabase();

            foreach (string filePath in _listPreConversionScript)
            {
                try
                {
                    StreamReader reader = new StreamReader(filePath);
                    string sqlScript = reader.ReadToEnd();
                    _sourceDatabase.ExecuteScript(sqlScript);
                    reader.Close();
                }
                catch (Exception exc)
                {
                    Logger.Error("Can not run pre-conversion script from " + filePath);
                }
            }
        }

        private string DoConversion()
        {
            Logger.Info("Doing conversion");

            List<string> scriptNames = new List<string>();
            Dictionary<string, string> bcpExportCommands = new Dictionary<string, string>();
            Dictionary<string, string> bcpImportCommands = new Dictionary<string, string>();

            _destinationDatabase.Tables.ForEach(t =>
            {
                DestinationTable destinationTable = t;
                SourceTable sourceTable = null;
                try
                {
                    Logger.Info("Processing " + destinationTable.Name);

                    TableMappingConfiguration mappingConfig = GetTableMappingConfig(destinationTable.Name);
                    sourceTable = GetSourceTable(destinationTable.Name, mappingConfig);
                    var mappingDefinition = CreateTableMappingDefinition(sourceTable, destinationTable, mappingConfig);
                    SqlGenerator sqlGenerator = new SqlGenerator(mappingDefinition, _options.CheckExistData);
                    BcpGenerator bcpGenerator = new BcpGenerator(_options.ServerName, _options.InstanceName, mappingDefinition, _options.BcpMode);

                    HandleBcp(sqlGenerator, bcpGenerator, mappingDefinition, bcpExportCommands, bcpImportCommands);
                    HandleMaxTextUpdate(sqlGenerator, mappingDefinition, scriptNames);
                    if(_options.BlobHandling)
                    {
                        HandleBlobUpdate(sqlGenerator, mappingDefinition, scriptNames);
                    }
                }
                catch (AppException ex)
                {
                    if (ex.ErrorCode == AppExceptionCodes.DATABASE_ERROR_TABLE_NOT_FOUND)
                    {
                        Logger.Warn(destinationTable.Name + " not mapped");
                    }
                }
            });

            // Generate bat file
            string exportScript = BatGenerator.GenerateBcpExecuteBat(bcpExportCommands);
            SaveToFile(_packageOutputPath, "BCP_Export.bat", exportScript);
            Logger.Info("BCP Exporting data");
            Process.Start(new ProcessStartInfo { WorkingDirectory = _packageOutputPath, FileName = "BCP_Export.bat" });

            string importScript = BatGenerator.GenerateBcpExecuteBat(bcpImportCommands);
            //SaveToFile(_packageOutputPath, "BCP_Import.bat", importScript);

            List<string> scriptPaths = scriptNames.Select(s => Path.Combine(CONVERSION_PACKAGE_FOLDER, s)).ToList();
            string updateScript = BatGenerator.GenerateSqlExecuteBat(scriptPaths, _options.ServerName, _options.InstanceName, _options.Username, _options.Password);
            //SaveToFile(_packageOutputPath, "Update_Blob_Text.bat", updateScript);

            string batScript = importScript + Environment.NewLine + updateScript;
            return batScript;
        }

        private string DoPostConversion()
        {
            Logger.Info("Doing post-conversion job");

            foreach (string filePath in _listPostConversionScript)
            {
                string destPath = Path.Combine(_packageOutputPath, POST_CONVERSION_PACKAGE_FOLDER, Path.GetFileName(filePath));
                File.Copy(filePath, destPath);
            }

            List<string> scriptPaths = _listPostConversionScript.Select(s => Path.Combine(POST_CONVERSION_PACKAGE_FOLDER, Path.GetFileName(s))).ToList();
            string updateScript = BatGenerator.GenerateSqlExecuteBat(scriptPaths, _options.ServerName, _options.InstanceName, _options.Username, _options.Password);
            //SaveToFile(_packageOutputPath, "Run_Post_Conversion.bat", updateScript);

            return updateScript;
        }

        private void HandleBcp(SqlGenerator sqlGenerator, BcpGenerator bcpGenerator, TableMappingDefinition mappingDefinition, Dictionary<string, string> bcpExportCommands, Dictionary<string, string> bcpImportCommands)
        {
            Logger.Info("Handling BCP");

            SourceTable srcTable = mappingDefinition.SourceTable;
            DestinationTable destTable = mappingDefinition.DestinationTable;
            string bcpPackagePath = Path.Combine(_packageOutputPath, CONVERSION_PACKAGE_FOLDER);

            // Generate and save format file
            Logger.Info("Generating BCP format file for EXPORT");
            string bcpExportFormatFile = bcpGenerator.GenerateFormatFile(BcpDirection.Export);
            string exportFmtFileName = string.Format("{0}_EXPORT.fmt", destTable.Name);
            string exportFmtFilePath = Path.Combine(CONVERSION_PACKAGE_FOLDER, exportFmtFileName);
            SaveToFile(bcpPackagePath, exportFmtFileName, bcpExportFormatFile);

            Logger.Info("Generating BCP format file for IMPORT");
            string bcpImportFormatFile = bcpGenerator.GenerateFormatFile(BcpDirection.Import);
            string importFmtFileName = string.Format("{0}_IMPORT.fmt", destTable.Name);
            string importFmtFilePath = Path.Combine(CONVERSION_PACKAGE_FOLDER, importFmtFileName);
            SaveToFile(bcpPackagePath, importFmtFileName, bcpImportFormatFile);
            
            // Generate export, import commands
            Logger.Info("Generating BCP Export/Import commands");
            string bcpSelect = sqlGenerator.GenerateSelectStatement();
            string dataFileName = string.Format("{0}-{1}_BCP.txt", srcTable.Name, destTable.Name);
            string dataFilePath = Path.Combine(CONVERSION_PACKAGE_FOLDER, dataFileName);
            File.Create(Path.Combine(_packageOutputPath, dataFilePath));
            var bcpExportCommand = bcpGenerator.GenerateExportCommand(bcpSelect, exportFmtFilePath, dataFilePath);
            bcpExportCommands.Add(dataFileName, bcpExportCommand);
            var bcpImportCommand = bcpGenerator.GenerateImportCommand(importFmtFilePath, dataFilePath);
            bcpImportCommands.Add(dataFileName, bcpImportCommand);
        }

        private void HandleBlobUpdate(SqlGenerator sqlGenerator, TableMappingDefinition mappingDefinition, List<string> scriptNames)
        {
            Logger.Info("Handling BLOB");

            SourceTable srcTable = mappingDefinition.SourceTable;
            DestinationTable destTable = mappingDefinition.DestinationTable;
            string postSqlPackagePath = Path.Combine(_packageOutputPath, CONVERSION_PACKAGE_FOLDER);

            Logger.Info("Generating script for updating blob fields");
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
            Logger.Info("Handling max text");

            SourceTable srcTable = mappingDefinition.SourceTable;
            DestinationTable destTable = mappingDefinition.DestinationTable;
            string postSqlPackagePath = Path.Combine(_packageOutputPath, CONVERSION_PACKAGE_FOLDER);

            Logger.Info("Generating script for updating max text fields");
            string script = sqlGenerator.GenerateVarCharMaxUpdateScript();
            if(!string.IsNullOrEmpty(script))
            {
                var fileName = string.Format("{0}-{1}_TEXT.sql", srcTable.Name, destTable.Name);
                SaveToFile(postSqlPackagePath, fileName, script);
                scriptNames.Add(fileName);
            }
        }

        #endregion
        
        public void AddPreConversionScript(string filePath)
        {
            _listPreConversionScript.Add(filePath);
        }

        public void AddPostConversionScript(string filePath)
        {
            _listPostConversionScript.Add(filePath);
        }

        private TableMappingDefinition CreateTableMappingDefinition(SourceTable srcTable, DestinationTable destTable, TableMappingConfiguration mappingConfig)
        {
            TableMappingDefinition mappingDefinition;
            if (mappingConfig != null)
            {
                mappingDefinition = new TableMappingDefinition(srcTable, destTable, mappingConfig.FieldMappings);
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
                Directory.CreateDirectory(_packageOutputPath);
            }

            Directory.CreateDirectory(Path.Combine(_packageOutputPath, CONVERSION_PACKAGE_FOLDER));
            Directory.CreateDirectory(Path.Combine(_packageOutputPath, BLOB_PACKAGE_FOLDER));
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
