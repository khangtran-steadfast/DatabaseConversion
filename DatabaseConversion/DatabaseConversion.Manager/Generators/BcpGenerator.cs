using DatabaseConversion.DatabaseAccess;
using DatabaseConversion.Manager.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringInject;
using DatabaseConversion.Manager.MappingDefinitions;
using System.IO;
using DatabaseConversion.Common.Enums;

namespace DatabaseConversion.Manager.Generators
{
    class BcpGenerator
    {
        private string _serverName { get; set; }
        private string _instanceName { get; set; }

        public BcpGenerator(string serverName, string instanceName)
        {
            _serverName = serverName;
            _instanceName = instanceName;
        }

        public string GenerateExportCommand(DestinationTable table, string query, string formatFilePath, string outputPath)
        {
            string command = BcpTemplates.BCP_EXPORT.Inject(new
            {
                ServerName = _serverName,
                InstanceName = _instanceName,
                Query = query,
                OutputPath = outputPath,
                FormatFilePath = formatFilePath,
                LogPath = @"BCP_LOG.txt"
            });

            return command;
        }

        public string GenerateImportCommand(DestinationTable table, string formatFilePath, string dataFilePath)
        {
            string command = BcpTemplates.BCP_IMPORT.Inject(new
            {
                ServerName = _serverName,
                InstanceName = _instanceName,
                TableFullName = table.FullName,
                FormatFilePath = formatFilePath,
                DataFilePath = dataFilePath,
                LogPath = @"BCP_LOG.txt"
            });

            return command;
        }

        public string GenerateFormatFile(TableMappingDefinition tableMappingDef, BcpDirection direction)
        {
            List<FieldMappingDefinition> fieldMappingDefs = tableMappingDef.FieldMappingDefinitions;
            string fields = "";
            int count = 0;
            foreach (var definition in tableMappingDef.FieldMappingDefinitions)
            {
                if (definition.Type != FieldMappingType.Simple
                    || definition.DestinationField.DataType.Contains("max")
                    || definition.DestinationField.DataType.Contains("text")) // have a problem with (max) datatype in bcp so we handle it seperately) 
                { 
                    continue; 
                }

                string dataType = definition.DestinationField.SqlDataType;
                int prefixLength = definition.DestinationField.PrefixLength;
                int length = definition.DestinationField.Length;
                int serverColumnOrder = definition.DestinationField.Order;
                string serverColumnName = definition.DestinationField.Name;
                string collation = definition.DestinationField.Collation;
                fields += BcpTemplates.BCP_FORMAT_ROW.Inject(new
                {
                    Index = ++count,
                    DataType = dataType,
                    PrefixLength = prefixLength,
                    Length = length,
                    ServerColumnOrder = direction == BcpDirection.Export ? count : serverColumnOrder,
                    ServerColumnName = serverColumnName,
                    Collation = string.IsNullOrEmpty(collation) ? @"""""" : collation
                }) + Environment.NewLine;  
            }

            string formatFile = BcpTemplates.BCP_FORMAT_FILE.Inject(new
            {
                FieldCount = count,
                Fields = fields
            });

            return formatFile;
        }
    }

    enum BcpDirection
    {
        Import,
        Export
    }
}
