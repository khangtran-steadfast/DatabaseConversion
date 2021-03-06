﻿using DatabaseConversion.DatabaseAccess;
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
        private string _serverName;
        private string _instanceName;
        private TableMappingDefinition _definition;
        private BcpMode _mode;

        public BcpGenerator(string serverName, string instanceName, TableMappingDefinition definition, BcpMode mode)
        {
            _serverName = serverName;
            _instanceName = instanceName;
            _definition = definition;
            _mode = mode;
        }

        public string GenerateExportCommand(string query, string formatFilePath, string outputPath)
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

        public string GenerateImportCommand(string formatFilePath, string dataFilePath)
        {
            string command = BcpTemplates.BCP_IMPORT.Inject(new
            {
                ServerName = _serverName,
                InstanceName = _instanceName,
                TableFullName = _definition.DestinationTable.FullName,
                FormatFilePath = formatFilePath,
                DataFilePath = dataFilePath,
                LogPath = @"BCP_LOG.txt"
            });

            return command;
        }

        public string GenerateFormatFile(BcpDirection direction)
        {
            List<FieldMappingDefinition> fieldMappingDefs = _definition.FieldMappingDefinitions;
            string fields = "";
            int count = 0;
            for (int i = 0; i < fieldMappingDefs.Count; i++)
            {
                FieldMappingDefinition definition = fieldMappingDefs[i];
                if (definition.Type != FieldMappingType.Simple)
                {
                    continue;
                }

                // have a problem with (max) datatype in bcp so we handle it seperately
                if ((definition.DestinationField.IsMaxDataType) && _definition.HandleMaxTextSeperately)
                {
                    continue;
                }

                string bcpFormat;
                if (_mode == BcpMode.Native)
                {
                    bcpFormat = BcpTemplates.BCP_NATIVE_FORMAT_ROW;
                }
                else
                {
                    bcpFormat = i < fieldMappingDefs.Count - 1 ? BcpTemplates.BCP_CHARACTER_FORMAT_ROW
                                                                                      : BcpTemplates.BCP_CHARACTER_FORMAT_LAST_ROW;
                }

                string dataType = definition.DestinationField.SqlDataType;
                int prefixLength = definition.DestinationField.PrefixLength;
                int length = definition.DestinationField.Length;
                int serverColumnOrder = definition.DestinationField.Order;
                string serverColumnName = definition.DestinationField.Name;
                string collation = definition.DestinationField.Collation;
                fields += bcpFormat.Inject(new
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

    public enum BcpDirection
    {
        Import,
        Export
    }

    public enum BcpMode
    {
        Native,
        Character
    }
}
