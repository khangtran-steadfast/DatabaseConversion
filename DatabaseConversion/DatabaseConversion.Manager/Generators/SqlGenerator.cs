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
        private SourceDatabase _sourceDatabase;
        private TableMappingDefinition _definition;

        public SqlGenerator(SourceDatabase sourceDatabase, TableMappingDefinition definition)
        {
            _sourceDatabase = sourceDatabase;
            _definition = definition;
        }

        public string GenerateSelectStatement()
        {
            string selectFields = GenerateSelectFields();

            var result = SqlTemplates.SELECT.Inject(new
            {
                Fields = selectFields,
                TableFullName = _definition.SourceTable.FullName
            });

            return result;
        }

        public string GenerateBlobPointerUpdateScript()
        {
            string result = "";

            List<FieldMappingDefinition> blobMappings = GetBlobMappings();
            if(blobMappings.Any())
            {
                string createTempTableScript = @"CREATE TABLE #Temp (Id int, Value varchar(MAX))";
                string insertScript = string.Format(SqlTemplates.INSERT, "#Temp", "[Id], [Value]");
                string dropTempTableScript = @"DROP TABLE #Temp";
                string truncateTempTableScript = @"TRUNCATE TABLE #Temp";

                string script = "";
                Field srcPK = _definition.SourceTable.GetPrimaryKey();
                Field destPK = _definition.DestinationTable.GetPrimaryKey();
                blobMappings.ForEach(m =>
                {
                    // Insert blob pointer into temp table
                    StringBuilder valuesScriptBuilder = new StringBuilder();
                    var blobs = _sourceDatabase.GetBlobs(_definition.SourceTable.Name, m.SourceField.Name);
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
                        SourcePK = srcPK.Name,
                        TargetField = m.DestinationField.Name,
                        SourceField = "Value"
                    });

                    script += insertBlobPointerScript + NewLines(2) + mergeBlobPointerScript + NewLines(2) + truncateTempTableScript + NewLines(2);
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
                if (definition.Type != FieldMappingType.Simple) { continue; }

                string field;
                Field destField = definition.DestinationField;
                Field srcField = definition.SourceField;

                if (!string.IsNullOrEmpty(definition.ForceValue))
                {
                    field = string.Format("'{0}'", definition.ForceValue);
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
