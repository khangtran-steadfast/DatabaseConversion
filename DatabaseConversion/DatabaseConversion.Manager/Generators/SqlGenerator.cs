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
        private bool _checkExistData;

        public SqlGenerator(TableMappingDefinition definition, bool checkExistData)
        {
            _definition = definition;
            _checkExistData = checkExistData;
        }

        public string GenerateSelectStatement()
        {
            string result;

            string selectFields = GenerateSelectFields();
            if (_checkExistData)
            {
                // Exclude exist data on PK, Unique
                List<string> notInClauseList = new List<string>();
                List<Field> uniqueFields = _definition.DestinationTable.Fields.Where(f => f.IsUnique).ToList();
                uniqueFields.ForEach(f =>
                {
                    List<string> existingValues = _definition.DestinationTable.GetValues(f.Name);
                    if (existingValues.Any())
                    {
                        string notInClause = SqlTemplates.WHERE_NOT_IN.Inject(new
                        {
                            Field = f.Name,
                            Values = existingValues.Select(x => string.Format("'{0}'", EscapeSingleQuote(x))).Aggregate((x, y) => x + "," + y)
                        });

                        notInClauseList.Add(notInClause);
                    }
                });

                if(notInClauseList.Any())
                {
                    result = SqlTemplates.SELECT_WHERE.Inject(new
                    {
                        Fields = selectFields,
                        TableFullName = _definition.SourceTable.FullName,
                        Conditions = notInClauseList.Aggregate((x, y) => x + " AND " + y)
                    });
                }
                else
                {
                    result = SqlTemplates.SELECT.Inject(new
                    {
                        Fields = selectFields,
                        TableFullName = _definition.SourceTable.FullName,
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

                int emptyBlobsCount = 0;
                string script = "";
                Field destPK = _definition.DestinationTable.GetPrimaryKey();
                blobMappings.ForEach(m =>
                {
                    // Insert blob pointer into temp table
                    StringBuilder valuesScriptBuilder = new StringBuilder();
                    var blobs = _definition.SourceTable.GetBlobs(m.SourceField.Name);
                    if(blobs.Any())
                    {
                        blobs.ForEach(b =>
                        {
                            byte[] data = b.Value;
                            string blobPointer = BlobConverter.ConvertToFile(m.BlobCategory, m.BlobCategory, data);
                            valuesScriptBuilder.Append(Environment.NewLine + string.Format("('{0}','{1}')", b.Key, blobPointer) + ",");
                        });
                    }
                    else
                    {
                        emptyBlobsCount++;
                    }

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

                // Prevent there is no blobs to update
                if(blobMappings.Count != emptyBlobsCount)
                {
                    result = createTempTableScript + NewLines(2) + script + dropTempTableScript;
                }
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

            if(_definition.HandleMaxTextSeperately)
            {
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
            }

            return result;
        }

        private string GenerateSelectFields()
        {
            List<string> fields = new List<string>();
            foreach (FieldMappingDefinition definition in _definition.FieldMappingDefinitions)
            {
                if (definition.Type != FieldMappingType.Simple)
                {
                    continue;
                }

                // have a problem with (max) datatype in bcp so we handle it seperately
                if (definition.DestinationField.IsMaxDataType && _definition.HandleMaxTextSeperately)
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

        private string EscapeSingleQuote(string input)
        {
            return input.Replace("'", "''");
        }
    }
}
