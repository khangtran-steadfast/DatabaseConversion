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
        #region Fields

        private SqlConnection _connection;

        // Dump query to get schema only
        private const string DUMP_QUERY = "SELECT * FROM {0} WHERE 0=1";
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
            string query = string.Format(DUMP_QUERY, Name);
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, _connection))
            {
                List<string> primaryKeys = ReadPrimaryKeys();
                //List<string> varCharMaxFields = ReadVarCharMaxFields();

                DataTable table = new DataTable(Name);
                DataColumnCollection columns = adapter.FillSchema(table, SchemaType.Mapped).Columns;
                foreach (DataColumn column in columns)
                {
                    Field field = new Field
                    {
                        Name = column.ColumnName, 
                        Order = column.Ordinal + 1, 
                        DataType = column.DataType.Name 
                    };

                    if (primaryKeys.Contains(field.Name))
                    {
                        field.IsPrimaryKey = true;
                    }

                    //if(varCharMaxFields.Contains(field.Name))
                    //{
                    //    field.IsVarCharMax = true;
                    //}

                    if (column.AllowDBNull)
                    {
                        field.AllowNull = true;
                    }

                    Fields.Add(field);
                }
            }
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

        private List<string> ReadVarCharMaxFields()
        {
            List<string> result = new List<string>();

            string getDataTypesTemplate = @"SELECT *
                                            FROM {0}.INFORMATION_SCHEMA.COLUMNS
                                            WHERE TABLE_NAME = N'{1}'";

            string getDataTypesQuery = string.Format(getDataTypesTemplate, DatabaseName, Name);
            using (SqlDataAdapter adapter = new SqlDataAdapter(getDataTypesQuery, _connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    var fieldName = row["COLUMN_NAME"].ToString();
                    var dataType = row["DATA_TYPE"].ToString();
                    var length = (int)row["CHARACTER_MAXIMUM_LENGTH"];

                    if (((dataType.Equals("varchar", StringComparison.InvariantCultureIgnoreCase)
                        || dataType.Equals("nvarchar", StringComparison.InvariantCultureIgnoreCase)) && length == -1)
                        || dataType.Equals("text", StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Add(fieldName);
                    }
                }
            }

            return result;
        }
    }
}
