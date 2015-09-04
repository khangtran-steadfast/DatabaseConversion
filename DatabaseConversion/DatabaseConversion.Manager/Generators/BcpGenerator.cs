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
                LogPath = @"Migration_Log.txt"
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
                LogPath = @"Migration_Log.txt"
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
                string format = i == fieldMappingDefs.Count - 1 ? BcpTemplates.BCP_FORMAT_LAST_ROW : BcpTemplates.BCP_FORMAT_ROW;

                FieldMappingDefinition fieldMappingDef = fieldMappingDefs[i];
                int serverColumnOrder = fieldMappingDef.DestinationField.Order;
                string serverColumnName = fieldMappingDef.DestinationField.Name;
                fields += format.Inject(new
                {
                    Index = i + 1,
                    ServerColumnOrder = serverColumnOrder,
                    ServerColumnName = serverColumnName
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
