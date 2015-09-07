using DatabaseConversion.DatabaseAccess;
using DatabaseConversion.Manager.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringInject;
using DatabaseConversion.Manager.MappingDefinitions;

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

        public string GenerateFormatFile(TableMappingDefinition tableMappingDef)
        {
            List<FieldMappingDefinition> fieldMappingDefs = tableMappingDef.FieldMappingDefinitions;
            int fieldCount = fieldMappingDefs.Count;
            string fields = "";
            for (int i = 0; i < fieldMappingDefs.Count; i++)
            {
                FieldMappingDefinition fieldMappingDef = fieldMappingDefs[i];
                string dataType = fieldMappingDef.DestinationField.DataType;
                int prefixLength = fieldMappingDef.DestinationField.PrefixLength;
                int length = fieldMappingDef.DestinationField.Length;
                int serverColumnOrder = fieldMappingDef.DestinationField.Order;
                string serverColumnName = fieldMappingDef.DestinationField.Name;
                string collation = fieldMappingDef.DestinationField.Collation;
                fields += BcpTemplates.BCP_FORMAT_ROW.Inject(new
                {
                    Index = i + 1,
                    DataType = dataType,
                    PrefixLength = prefixLength,
                    Length = length,
                    ServerColumnOrder = serverColumnOrder,
                    ServerColumnName = serverColumnName,
                    Collation = string.IsNullOrEmpty(collation) ? @"""""" : collation
                }) + Environment.NewLine;
            }

            string formatFile = BcpTemplates.BCP_FORMAT_FILE.Inject(new
            {
                FieldCount = fieldCount,
                Fields = fields
            });

            return formatFile;
        }
    }
}
