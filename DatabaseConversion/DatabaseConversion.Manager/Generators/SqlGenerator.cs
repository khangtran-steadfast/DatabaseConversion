using DatabaseConversion.DatabaseAccess;
using DatabaseConversion.Manager.Constants;
using DatabaseConversion.Manager.MappingDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringInject;
using DatabaseConversion.Common.Enums;
using DatabaseConversion.Manager.BlobStoreProviders;

namespace DatabaseConversion.Manager.Generators
{
    class SqlGenerator
    {
        private TableMappingDefinition _definition;

        public SqlGenerator(TableMappingDefinition definition)
        {
            _definition = definition;
        }

        public string GenerateSelectStatement()
        {
            string result;

            string selectFields = GenerateSelectFields();
            if (_definition.ExcludeExistData)
            {
                Field primaryKey = _definition.DestinationTable.GetPrimaryKey();
                List<int> existIds = _definition.DestinationTable.GetIds();
                if(existIds.Any())
                {
                    // Generate where clause to exclude exist data
                    string notInClause = SqlTemplates.WHERE_NOT_IN.Inject(new
                    {
                        Field = primaryKey.Name,
                        Values = existIds.Select(x => x.ToString()).Aggregate((x, y) => x + "," + y)
                    });


                    result = SqlTemplates.SELECT_WHERE.Inject(new
                    {
                        Fields = selectFields,
                        TableFullName = _definition.SourceTable.FullName,
                        Conditions = notInClause
                    });
                }
                else
                {
                    result = SqlTemplates.SELECT.Inject(new
                    {
                        Fields = selectFields,
                        TableFullName = _definition.SourceTable.FullName
                    });
                }
            }
            else
            {
                // Just select all
                result = SqlTemplates.SELECT.Inject(new
                {
                    Fields = selectFields,
                    TableFullName = _definition.SourceTable.FullName
                });
            }

            return result;
        }

        public string GenerateBlobFieldUpdateScript()
        {
            string result = "";

            List<FieldMappingDefinition> blobMappings = GetBlobMappings();
            if (blobMappings.Any())
            {
                // Create temp table to store blob pointer
                string createTempTableScript = @"CREATE TABLE #Temp (Id int, Value varchar(MAX))";
                string insertScript = string.Format(SqlTemplates.INSERT, "#Temp", "[Id], [Value]");
                string dropTempTableScript = @"DROP TABLE #Temp";
                string truncateTempTableScript = @"TRUNCATE TABLE #Temp";

                string script = "";
                Field destPK = _definition.DestinationTable.GetPrimaryKey();
                blobMappings.ForEach(m =>
                {
                    // Insert blob pointer into temp table
                    StringBuilder valuesScriptBuilder = new StringBuilder();
                    var blobs = _definition.SourceTable.GetBlobs(m.SourceField.Name);
                    blobs.ForEach(b =>
                    {
                        byte[] data = b.Value;
                        string blobPointer = BlobConverter.ConvertToFile(m.BlobCategory, m.BlobCategory, data);
                        valuesScriptBuilder.Append(Environment.NewLine + string.Format("('{0}','{1}')", b.Key, blobPointer) + ",");
                    });

                    string valuesScript = valuesScriptBuilder.ToString().Trim(',');
                    string insertBlobPointerScript = insertScript + NewLines(1) + string.Format(SqlTemplates.INSERT_VALUES, valuesScript);

                    // Merge blob pointer into destination table
                    string mergeBlobPointerScript = SqlTemplates.MERGE_UPDATE.Inject(new
                    {
                        TargetTable = _definition.DestinationTable.FullName,
                        SourceTable = "#Temp",
                        TargetPK = destPK.Name,
                        SourcePK = "Id",
                        TargetField = m.DestinationField.Name,
                        SourceField = "Value"
                    });

                    script += insertBlobPointerScript + NewLines(2) + mergeBlobPointerScript + NewLines(2) + truncateTempTableScript + NewLines(2);
                });

                result = createTempTableScript + NewLines(2) + script + dropTempTableScript;
            }

            return result;
        }

        /// <summary>
        /// There is a problem with varchar(max) column in bcp when there is a mismatch between the number of varchar(max) columns 
        /// in datafile and target table. So we handle it seperately
        /// </summary>
        /// <returns></returns>
        public string GenerateVarCharMaxUpdateScript()
        {
            string result = "";

            List<FieldMappingDefinition> mappings = GetVarCharMaxMappings();
            if (mappings.Any())
            {
                // Create temp table to store char
                string createTempTableScript = @"CREATE TABLE #Temp (Id int, Value varchar(MAX))";
                string insertScript = string.Format(SqlTemplates.INSERT, "#Temp", "[Id], [Value]");
                string dropTempTableScript = @"DROP TABLE #Temp";
                string truncateTempTableScript = @"TRUNCATE TABLE #Temp";

                string script = "";
                Field destPK = _definition.DestinationTable.GetPrimaryKey();
                mappings.ForEach(m =>
                {
                    // Insert chars into temp table
                    StringBuilder valuesScriptBuilder = new StringBuilder();
                    var chars = _definition.SourceTable.GetChars(m.SourceField.Name);
                    chars.ForEach(b =>
                    {
                        string data = b.Value;
                        valuesScriptBuilder.Append(Environment.NewLine + string.Format("('{0}','{1}')", b.Key, data) + ",");
                    });

                    string valuesScript = valuesScriptBuilder.ToString().Trim(',');
                    string insertCharsScript = insertScript + NewLines(1) + string.Format(SqlTemplates.INSERT_VALUES, valuesScript);

                    // Merge chars into destination table
                    string mergeCharsScript = SqlTemplates.MERGE_UPDATE.Inject(new
                    {
                        TargetTable = _definition.DestinationTable.FullName,
                        SourceTable = "#Temp",
                        TargetPK = destPK.Name,
                        SourcePK = "Id",
                        TargetField = m.DestinationField.Name,
                        SourceField = "Value"
                    });

                    script += insertCharsScript + NewLines(2) + mergeCharsScript + NewLines(2) + truncateTempTableScript + NewLines(2);
                });

                result = createTempTableScript + NewLines(2) + script + dropTempTableScript;
            }

            return result;
        }

        private string GenerateSelectFields()
        {
            List<string> fields = new List<string>();
            foreach (FieldMappingDefinition definition in _definition.FieldMappingDefinitions)
            {
                if (definition.Type != FieldMappingType.Simple
                    || definition.DestinationField.DataType.Contains("max")
                    || definition.DestinationField.DataType.Contains("text")) // have a problem with (max) datatype in bcp so we handle it seperately
                { 
                    continue; 
                }

                string field;
                Field destField = definition.DestinationField;
                Field srcField = definition.SourceField;

                if (!string.IsNullOrEmpty(definition.ForceValue))
                {
                    if(definition.ForceValue.Equals("DATETIMENOW", StringComparison.InvariantCultureIgnoreCase))
                    {
                        field = string.Format("{0}", "GETDATE()");
                    }
                    else
                    {
                        field = string.Format("'{0}'", definition.ForceValue);
                    }
                }
                else if (srcField.Name.Contains("created_who"))
                {
                    field = SqlTemplates.FIELD_NULL_DEFAULT_VALUE.Inject(new
                    {
                        FieldName = srcField.Name,
                        Value = "'Database Migration Tool'"
                    });
                }
                else if (srcField.Name.Contains("created_when"))
                {
                    field = SqlTemplates.FIELD_NULL_DEFAULT_VALUE.Inject(new
                    {
                        FieldName = srcField.Name,
                        Value = "GETDATE()"
                    });
                }
                else
                {
                    field = string.Format(SqlTemplates.FIELD, srcField.Name);
                }

                fields.Add(field);
            }

            string result = fields.Aggregate((x, y) => x + "," + y);
            return result;
        }

        private List<FieldMappingDefinition> GetBlobMappings()
        {
            List<FieldMappingDefinition> result = _definition.FieldMappingDefinitions.Where(d => d.Type == FieldMappingType.BlobToBlobPointer || d.Type == FieldMappingType.BlobToHtml).ToList();
            return result;
        }

        private List<FieldMappingDefinition> GetVarCharMaxMappings()
        {
            List<FieldMappingDefinition> result = _definition.FieldMappingDefinitions.Where(d => d.DestinationField.DataType.Contains("varchar(max)") || d.DestinationField.DataType.Contains("text")).ToList();
            return result;
        }

        private string NewLines(int count)
        {
            string lines = "";

            for (int i = 0; i < count; i++)
            {
                lines += Environment.NewLine;
            }

            return lines;
        }
    }
}
