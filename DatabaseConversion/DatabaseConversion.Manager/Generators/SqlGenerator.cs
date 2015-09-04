using DatabaseConversion.DatabaseAccess;
using DatabaseConversion.Manager.Constants;
using DatabaseConversion.Manager.MappingDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringInject;

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

        public string GenerateSelect()
        {
            string selectFields = GenerateSelectFields();

            var result = SqlTemplates.SELECT.Inject(new
            {
                Fields = selectFields,
                TableFullName = _definition.SourceTable.FullName
            });

            return result;
        }

        //public string HandleVarCharMaxFields()
        //{
        //    List<FieldMappingDefinition> mappings = GetVarCharMaxMappings();
        //    if(mappings.Any())
        //    {
        //        // Create temp table to store data
        //        var tempFields = mappings.Select(m => string.Format(SqlScriptTemplates.DECLARE_FIELD_VARCHAR_MAX, m.DestinationField.Name))
        //                                 .Aggregate((x, y) => x + "," + NewLines(1) + y);
        //        string createTempTableScript = string.Format(SqlScriptTemplates.CREATE_TEMP_TABLE, tempFields);

        //        // Insert data to temp table

        //    }

        //    return null;
        //}

//        public string HandleBlobFields()
//        {
//            List<FieldMappingDefinition> blobMappings = GetBlobMappings();
//            bool hasBlobs = blobMappings.Any();
//            if (hasBlobs)
//            {
//                Console.WriteLine("Handling Blob for " + _definition.SourceTable.Name);

//                string createTempTableScript =
//@"CREATE TABLE #Temp
//(
//	Id int,
//	Value nvarchar(MAX)
//)";

//                string insertScript = string.Format(SqlScriptTemplates.INSERT, "#Temp", "([Id], [Value])");
//                StringBuilder valuesScriptBuilder = new StringBuilder();
//                blobMappings.ForEach(m =>
//                {
//                    var blobs = _sourceDatabase.GetBlobs(_definition.SourceTable.Name, m.SourceField.Name);
//                    blobs.ForEach(b =>
//                    {
//                        string data = b.Value;
//                        //string blobPointer = BlobConverter.ConvertToFile(m.BlobCategory, m.BlobCategory, data);
//                        string blobPointer = "XXX";
//                        valuesScriptBuilder.Append(Environment.NewLine + string.Format("('{0}','{1}')", b.Key, blobPointer) + ",");
//                    });
//                });

//                string valuesScript = valuesScriptBuilder.ToString().Trim(',');
//                string blobScript = createTempTableScript + NewLines(2) + insertScript + NewLines(1) + string.Format(SqlScriptTemplates.INSERT_VALUES, valuesScript);
//                return blobScript;
//            }

//            return null;
//        }

        private string GenerateSelectFields()
        {
            List<string> fields = new List<string>();
            foreach (FieldMappingDefinition definition in _definition.FieldMappingDefinitions)
            {
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
    }
}
