using DatabaseConversion.Common.Configurations;
using DatabaseConversion.Common.Exceptions;
using DatabaseConversion.DatabaseAccess;
using DatabaseConversion.Manager.Generators;
using DatabaseConversion.Manager.MappingDefinitions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.Manager
{
    public class ConversionManager
    {
        private const string BCP_PACKAGE_FOLDER = "BCP";
        private const string BLOB_PACKAGE_FOLDER = "BLOB";
        private const string PRE_SQL_PACKAGE_FOLDER = "PreSQL";
        private const string POST_SQL_PACKAGE_FOLDER = "PostSQL";

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

                    // Generate BCP
                    string bcpPackagePath = Path.Combine(_packageOutputPath, BCP_PACKAGE_FOLDER);
                    string bcpFormatFile = _bcpGenerator.GenerateFormatFile(mappingDefinition);
                    string fmtFileName = string.Format("{0}.fmt", destinationTable.Name);
                    SaveToFile(bcpPackagePath, fmtFileName, bcpFormatFile);

                    SqlGenerator sqlGenerator = new SqlGenerator(_sourceDatabase, mappingDefinition);
                    string query = sqlGenerator.GenerateSelectStatement();
                    string dataFileName = string.Format("{0}-{1}.txt", sourceTable.Name, destinationTable.Name);
                    string dataFilePath = Path.Combine(BCP_PACKAGE_FOLDER, dataFileName);
                    string fmtFilePath = Path.Combine(BCP_PACKAGE_FOLDER, fmtFileName);
                    var bcpExportCommand = _bcpGenerator.GenerateExportCommand(destinationTable, query, fmtFilePath, dataFilePath);
                    bcpExportCommands.Add(dataFileName, bcpExportCommand);
                    var bcpImportCommand = _bcpGenerator.GenerateImportCommand(destinationTable, fmtFilePath, dataFilePath);
                    bcpImportCommands.Add(dataFileName, bcpImportCommand);

                    // Generate BLOB
                    string blobScript = sqlGenerator.GenerateBlobPointerUpdateScript();
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

            string importScript = BatGenerator.GenerateBcpExecuteBat(bcpImportCommands);
            SaveToFile(_packageOutputPath, "BCP_Import.bat", importScript);
        }

        private void GeneratePostConversionPackage()
        {
            // TODO
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
            Directory.CreateDirectory(Path.Combine(_packageOutputPath, BCP_PACKAGE_FOLDER));
            Directory.CreateDirectory(Path.Combine(_packageOutputPath, BLOB_PACKAGE_FOLDER));
            Directory.CreateDirectory(Path.Combine(_packageOutputPath, PRE_SQL_PACKAGE_FOLDER));
            Directory.CreateDirectory(Path.Combine(_packageOutputPath, POST_SQL_PACKAGE_FOLDER));
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
