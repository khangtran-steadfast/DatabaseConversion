using DatabaseConversion.Common.Configurations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringInject;
using DatabaseConversion.Common.Exceptions;

namespace DatabaseConversion.DatabaseAccess
{
    public class SourceDatabase : Database<SourceTable>
    {
        public SourceDatabase(string connectionString)
            : base(connectionString)
        {

        }

        public void LearnPrimaryKeys(DestinationDatabase destDatabase, List<TableMappingConfiguration> tableMappingConfigs)
        {
            destDatabase.Tables.ForEach(destTable =>
            {
                try
                {
                    List<FieldMappingConfiguration> fieldMappingConfigs;
                    SourceTable srcTable = GetCorrespondingTable(destTable.Name, tableMappingConfigs, out fieldMappingConfigs);
                    destTable.Fields.Where(f => f.IsPrimaryKey).ToList().ForEach(f =>
                    {
                        Field srcField = srcTable.GetCorrespondingField(f.Name, fieldMappingConfigs);
                        if(srcField != null)
                        {
                            srcField.IsPrimaryKey = true;
                        }
                    });
                }
                catch (AppException ex)
                {
                    // TODO: Write log
                    if (ex.ErrorCode == AppExceptionCodes.DATABASE_ERROR_FIELD_NOT_FOUND)
                    {

                    }
                    else if (ex.ErrorCode == AppExceptionCodes.DATABASE_ERROR_TABLE_NOT_FOUND)
                    {

                    }
                }
            });
        }

        private SourceTable GetCorrespondingTable(string destinationTableName, List<TableMappingConfiguration> mappingConfigs, out List<FieldMappingConfiguration> fieldMappingConfigs)
        {
            fieldMappingConfigs = null;
            SourceTable sourceTable;
            if (mappingConfigs != null)
            {
                var mappingConfig = mappingConfigs.SingleOrDefault(m => m.DestinationTableName.Equals(destinationTableName, StringComparison.InvariantCultureIgnoreCase));
                if (mappingConfig != null)
                {
                    string mapSourceTableName = mappingConfig.SourceTableName != null ? mappingConfig.SourceTableName : destinationTableName;
                    sourceTable = GetTable(mapSourceTableName);
                    fieldMappingConfigs = mappingConfig.FieldMappings;
                }
                else
                {
                    string mapSourceTableName = destinationTableName;
                    sourceTable = GetTable(mapSourceTableName);
                }
            }
            else
            {
                string mapSourceTableName = destinationTableName;
                sourceTable = GetTable(mapSourceTableName);
            }

            return sourceTable;
        }
    }
}
