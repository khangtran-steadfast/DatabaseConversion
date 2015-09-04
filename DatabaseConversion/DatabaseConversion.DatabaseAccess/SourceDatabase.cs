using DatabaseConversion.Common.Configurations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringInject;

namespace DatabaseConversion.DatabaseAccess
{
    public class SourceDatabase : Database<SourceTable>
    {
        public SourceDatabase(string connectionString)
            : base(connectionString)
        {

        }

        public List<KeyValuePair<int, string>> GetBlobs(string tableName, string fieldName)
        {
            List<KeyValuePair<int, string>> result = new List<KeyValuePair<int, string>>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SourceTable table = GetTable(tableName);
                Field pkField = table.GetPrimaryKey();
                Field blobField = table.GetField(fieldName);

                string query = "SELECT {PrimaryKey}, {Blob} FROM {Table}".Inject(new { PrimaryKey = pkField.Name, Blob = blobField.Name, Table = table.FullName });
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable(table.Name);
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int id = (int)row[pkField.Name];
                        string blob = row[blobField.Name] == DBNull.Value ? null : (string)row[blobField.Name];
                        result.Add(new KeyValuePair<int, string>(id, blob));
                    }
                }
            }

            return result;
        }

        //public List<KeyValuePair<int, byte[]>> GetBlobs(string tableName, string fieldName)
        //{
        //    List<KeyValuePair<int, byte[]>> result = new List<KeyValuePair<int, byte[]>>();

        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        SourceTable table = GetTable(tableName);
        //        Field pkField = table.GetPrimaryKey();
        //        Field blobField = table.GetField(fieldName);

        //        string query = "SELECT {PrimaryKey}, {Blob} FROM {Table}".Inject(new { PrimaryKey = pkField.Name, Blob = blobField.Name, Table = table.FullName });
        //        using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
        //        {
        //            DataTable dataTable = new DataTable(table.Name);
        //            adapter.Fill(dataTable);
        //            foreach (DataRow row in dataTable.Rows)
        //            {
        //                int id = (int)row[pkField.Name];
        //                byte[] blob = row[blobField.Name] == DBNull.Value ? null : (byte[])row[blobField.Name];
        //                result.Add(new KeyValuePair<int, byte[]>(id, blob));
        //            }
        //        }
        //    }

        //    return result;
        //}
    }
}
