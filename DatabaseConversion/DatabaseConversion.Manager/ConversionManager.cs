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
        private ConversionOption _options;
        private SourceDatabase _sourceDatabase;
        private DestinationDatabase _destinationDatabase;
        private BcpGenerator _bcpGenerator;

        public ConversionManager(string srcConnectionString, string destConnectionString, ConversionOption options)
        {
            _options = options;

            _bcpGenerator = new BcpGenerator(options.ServerName, options.InstanceName);

            _sourceDatabase = new SourceDatabase(srcConnectionString);
            _sourceDatabase.Initialize();

            _destinationDatabase = new DestinationDatabase(destConnectionString);
            _destinationDatabase.Initialize();
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
            string outputPath = ConfigurationManager.AppSettings["SQLOutputFolder"];
            outputPath = Path.Combine(outputPath, DateTime.Now.ToString("ddMMyyyy"));
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
                    var bcpFormatFile = _bcpGenerator.GenerateFormatFile(mappingDefinition);
                    var fmtFileName = string.Format("{0}.fmt", destinationTable.Name);
                    SaveToFile(outputPath, fmtFileName, bcpFormatFile);

                    var sqlGenerator = new SqlGenerator(_sourceDatabase, mappingDefinition);
                    var query = sqlGenerator.GenerateSelect();
                    var dataFileName = string.Format("{0}-{1}.txt", sourceTable.Name, destinationTable.Name);
                    var bcpExportCommand = _bcpGenerator.GenerateExportCommand(destinationTable, query, fmtFileName, dataFileName);
                    bcpExportCommands.Add(dataFileName, bcpExportCommand);
                    var bcpImportCommand = _bcpGenerator.GenerateImportCommand(destinationTable, fmtFileName, dataFileName);
                    bcpImportCommands.Add(dataFileName, bcpImportCommand);


                    // Generate VARCHAR MAX Update
                    //fileName = string.Format("{0}-{1}.sql", sourceTable.Name, destinationTable.Name);
                    //script = scriptGenerator.HandleVarCharMaxFields();

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
            string exportScript = BatGenerator.GenerateBcpExecuteScript(bcpExportCommands);
            SaveToFile(outputPath, "ExportData.bat", exportScript);

            string importScript = BatGenerator.GenerateBcpExecuteScript(bcpImportCommands);
            SaveToFile(outputPath, "ImportData.bat", importScript);
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

        private void SaveToFile(string location, string fileName, string content)
        {
            string filePath = Path.Combine(location, fileName);

            FileInfo file = new FileInfo(filePath);
            file.Directory.Create();
            File.WriteAllText(file.FullName, content);
        }
    }
}
