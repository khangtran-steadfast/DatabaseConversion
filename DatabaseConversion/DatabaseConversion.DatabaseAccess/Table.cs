using DatabaseConversion.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.DatabaseAccess
{
    public abstract class Table
    {
        #region Dictionaries

        /*
         * https://msdn.microsoft.com/en-us/library/ms190779(v=sql.105).aspx
         * https://msdn.microsoft.com/en-us/library/ms177478(v=sql.105).aspx
         * */

        private Dictionary<string, int> PrefixLengths = new Dictionary<string, int>
        {
            {"char", 2},
            {"nchar", 2},
            {"varchar", 2},
            {"nvarchar", 2},
            {"text", 4},
            {"ntext", 4},
            {"binary", 2},
            {"varbinary", 2},
            {"image", 4},
            {"datetime", 0},
            {"smalldatetime", 0},
            {"date", 0},
            {"decimal", 1},
            {"numeric", 1},
            {"float", 0},
            {"real", 0},
            {"int", 0},
            {"bigint", 0},
            {"smallint", 0},
            {"tinyint", 0},
            {"money", 0},
            {"smallmoney", 0},
            {"bit", 0},
            {"uniqueidentifier", 1},
            {"timestamp", 1},
            {"varchar(max)", 8},
            {"varbinary(max)", 8},
            {"xml", 8},
        };

        private Dictionary<string, int> NullablePrefixLengths = new Dictionary<string, int>
        {
            {"char", 2},
            {"nchar", 2},
            {"varchar", 2},
            {"nvarchar", 2},
            {"text", 4},
            {"ntext", 4},
            {"binary", 2},
            {"varbinary", 2},
            {"image", 4},
            {"datetime", 1},
            {"smalldatetime", 1},
            {"date", 1},
            {"decimal", 1},
            {"numeric", 1},
            {"float", 1},
            {"real", 1},
            {"int", 1},
            {"bigint", 1},
            {"smallint", 1},
            {"tinyint", 1},
            {"money", 1},
            {"smallmoney", 1},
            {"bit", 1},
            {"uniqueidentifier", 1},
            {"timestamp", 1},
            {"varchar(max)", 8},
            {"varbinary(max)", 8},
            {"xml", 8},
        };

        private Dictionary<string, int> Lengths = new Dictionary<string, int>
        {
            {"text", 0},
            {"ntext", 0},
            {"bit", 1},
            {"image", 0},
            {"datetime", 8},
            {"smalldatetime", 4},
            {"date", 3},
            {"float", 8},
            {"real", 4},
            {"int", 4},
            {"bigint", 8},
            {"smallint", 2},
            {"tinyint", 1},
            {"money", 8},
            {"smallmoney", 4},
            {"uniqueidentifier", 16},
            {"timestamp", 8},
            {"xml", 0},
        };

        private Dictionary<string, string> SqlTypes = new Dictionary<string, string>
        {
            {"char", "SQLCHAR"},
            {"varchar", "SQLCHAR"},
            {"nchar", "SQLNCHAR"},
            {"nvarchar", "SQLNCHAR"},
            {"text", "SQLCHAR"},
            {"ntext", "SQLNCHAR"},
            {"binary", "SQLBINARY"},
            {"varbinary", "SQLBINARY"},
            {"image", "SQLBINARY"},
            {"datetime", "SQLDATETIME"},
            {"smalldatetime", "SQLDATETIM4"},
            {"date", "SQLDATE"},
            {"decimal", "SQLDECIMAL"},
            {"numeric", "SQLNUMERIC"},
            {"float", "SQLFLT8"},
            {"real", "SQLFLT4"},
            {"int", "SQLINT"},
            {"bigint", "SQLBIGINT"},
            {"smallint", "SQLSMALLINT"},
            {"tinyint", "SQLTINYINT"},
            {"money", "SQLMONEY"},
            {"smallmoney", "SQLMONEY4"},
            {"bit", "SQLBIT"},
            {"uniqueidentifier", "SQLUNIQUEID"},
            {"sql_variant", "SQLVARIANT"},
            {"timestamp", "SQLBINARY"},
            {"xml", "SQLNCHAR"},
        };

        #endregion

        #region Fields

        private SqlConnection _connection;

        private List<Field> _fields;

        #endregion

        #region Properties

        public string DatabaseName { get; set; }

        public string Schema { get; set; }

        public string Name { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("[{0}].{1}.[{2}]", DatabaseName, Schema, Name);
            }
        }

        public List<Field> Fields
        {
            get { return _fields ?? (_fields = new List<Field>()); }
        }

        #endregion

        public Field GetField(string fieldName)
        {
            try
            {
                var table = Fields.Single(t => t.Name.Equals(fieldName, StringComparison.InvariantCultureIgnoreCase));
                return table;
            }
            catch (InvalidOperationException)
            {
                throw new AppException(AppExceptionCodes.DATABASE_ERROR_FIELD_NOT_FOUND, fieldName);
            }
        }

        public Field GetPrimaryKey()
        {
            try
            {
                return _fields.First(f => f.IsPrimaryKey);
            }
            catch (InvalidOperationException)
            {
                throw new AppException(AppExceptionCodes.DATABASE_ERROR_PK_NOT_FOUND);
            }
        }

        public void Initialize(SqlConnection connection)
        {
            _connection = connection;

            ReadFieldsSchema();
        }

        private void ReadFieldsSchema()
        {
            string getFieldsSchemaTemplate = @"SELECT * 
                                            FROM INFORMATION_SCHEMA.COLUMNS
                                            WHERE TABLE_NAME = '{0}'";

            string query = string.Format(getFieldsSchemaTemplate, Name);
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, _connection))
            {
                List<string> primaryKeys = ReadPrimaryKeys();

                DataTable table = new DataTable(Name);
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    string fieldName = row["COLUMN_NAME"].ToString();
                    int order = Convert.ToInt32(row["ORDINAL_POSITION"]);
                    bool isNullable = row["IS_NULLABLE"].ToString().Equals("YES", StringComparison.InvariantCultureIgnoreCase) ? true : false;
                    string dataType = row["DATA_TYPE"].ToString();
                    string collationName = row["COLLATION_NAME"].ToString();
                    int characterMaximumLength = (row["CHARACTER_MAXIMUM_LENGTH"] == DBNull.Value ? -1 : Convert.ToInt32(row["CHARACTER_MAXIMUM_LENGTH"]));
                    int numericPrecision = (row["NUMERIC_PRECISION"] == DBNull.Value ? -1 : Convert.ToInt32(row["NUMERIC_PRECISION"]));

                    Field field = new Field
                    {
                        Name = fieldName,
                        Order = order,
                        DataType = SqlTypes[dataType],
                        AllowNull = isNullable,
                        PrefixLength = GetPrefixLength(dataType, isNullable, characterMaximumLength),
                        Length = GetLength(dataType, dataType.Equals("decimal") ? numericPrecision : dataType.Contains("char") ? characterMaximumLength : -1),
                        Collation = collationName
                    };

                    if (primaryKeys.Contains(field.Name))
                    {
                        field.IsPrimaryKey = true;
                    }

                    Fields.Add(field);
                }
            }
        }

        private int GetPrefixLength(string dataType, bool isNullable, int characterMaximumLength)
        {
            int result = -1;
            if ((dataType.Equals("char") || dataType.Equals("varchar")) && characterMaximumLength == -1)
            {
                return 8;
            }
            else if(isNullable)
            {
                result = NullablePrefixLengths[dataType];
            }
            else
            {
                result = PrefixLengths[dataType];
            }

            return result;
        }

        private int GetLength(string dataType, int parameter)
        {
            int result = -1;
            if (dataType.Equals("char") || dataType.Equals("varchar") || dataType.Equals("binary") || dataType.Equals("varbinary"))
            {
                result = parameter == -1 ? 0 : parameter;
            }
            else if(dataType.Equals("nchar") || dataType.Equals("nvarchar"))
            {
                result = parameter == -1 ? 0 : parameter * 2;
            }
            else if (dataType.Equals("decimal") || dataType.Equals("numeric"))
            {
                if(1 <= parameter && parameter <= 9)
                {
                    result = 5;
                }
                else if(10 <= parameter && parameter <= 19)
                {
                    result = 9;
                }
                else if(20 <= parameter && parameter <= 28)
                {
                    result = 13;
                }
                else if(29 <= parameter && parameter <= 38)
                {
                    result = 17;
                }
            }
            else
            {
                result = Lengths[dataType];
            }

            return result;
        }

        private List<string> ReadPrimaryKeys()
        {
            var result = new List<string>();

            string getPKTemplate = @"SELECT column_name
                                    FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                                    WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1
                                    AND table_name = '{0}'";
            string getPKQuery = string.Format(getPKTemplate, Name);
            using (SqlDataAdapter adapter = new SqlDataAdapter(getPKQuery, _connection))
            {
                DataTable table = new DataTable(Name);
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    var fieldName = row["column_name"].ToString();
                    result.Add(fieldName);
                }
            }

            return result;
        }
    }
}
