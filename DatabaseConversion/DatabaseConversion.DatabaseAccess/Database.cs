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
    public abstract class Database<T> where T : Table, new()
    {
        #region Fields

        protected string ConnectionString;
        private string _name;
        private List<T> _tables;

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
        }

        public List<T> Tables
        {
            get { return _tables ?? (_tables = new List<T>()); }
        }

        #endregion

        public Database(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Initialize()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                _name = connection.Database;
                ReadTablesSchema(connection);
            }
        }

        public void ExecuteScript(string sqlScript)
        {
            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlScript, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public T GetTable(string tableName)
        {
            try
            {
                var table = Tables.Single(t => t.Name.Equals(tableName, StringComparison.InvariantCultureIgnoreCase));
                return table;
            }
            catch (InvalidOperationException)
            {
                throw new AppException(AppExceptionCodes.DATABASE_ERROR_TABLE_NOT_FOUND, tableName);
            }
        }

        private void ReadTablesSchema(SqlConnection connection)
        {
            DataTable tableSchema = connection.GetSchema("Tables");
            foreach (DataRow row in tableSchema.Rows)
            {
                var catalog = row["TABLE_CATALOG"].ToString();
                var schema = row["TABLE_SCHEMA"].ToString();
                var name = row["TABLE_NAME"].ToString();
                var type = row["TABLE_TYPE"].ToString();

                if (type.Equals("BASE TABLE", StringComparison.InvariantCultureIgnoreCase))
                {
                    T table = new T { DatabaseName = catalog, Name = name, Schema = schema };
                    table.Initialize(connection);
                    Tables.Add(table);
                }
            }
        }
    }
}
