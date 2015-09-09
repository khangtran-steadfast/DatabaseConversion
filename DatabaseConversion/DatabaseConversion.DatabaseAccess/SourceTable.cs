using DatabaseConversion.Common.Configurations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringInject;
using System.Data;

namespace DatabaseConversion.DatabaseAccess
{
    public class SourceTable : Table
    {
        //public List<KeyValuePair<int, string>> GetBlobs(string tableName, string fieldName)
        //{
        //    List<KeyValuePair<int, string>> result = new List<KeyValuePair<int, string>>();

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
        //                string blob = row[blobField.Name] == DBNull.Value ? null : (string)row[blobField.Name];
        //                result.Add(new KeyValuePair<int, string>(id, blob));
        //            }
        //        }
        //    }

        //    return result;
        //}

        public List<KeyValuePair<int, byte[]>> GetBlobs(string fieldName)
        {
            List<KeyValuePair<int, byte[]>> result = new List<KeyValuePair<int, byte[]>>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Field pkField = GetPrimaryKey();
                Field blobField = GetField(fieldName);

                string query = "SELECT {PrimaryKey}, {Blob} FROM {Table}".Inject(new { PrimaryKey = pkField.Name, Blob = blobField.Name, Table = FullName });
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable(Name);
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int id = (int)row[pkField.Name];
                        byte[] blob = row[blobField.Name] == DBNull.Value ? null : (byte[])row[blobField.Name];
                        result.Add(new KeyValuePair<int, byte[]>(id, blob));
                    }
                }
            }

            return result;
        }

        public List<KeyValuePair<int, string>> GetChars(string fieldName)
        {
            List<KeyValuePair<int, string>> result = new List<KeyValuePair<int, string>>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Field pkField = GetPrimaryKey();
                Field charField = GetField(fieldName);

                string query = "SELECT {PrimaryKey}, {Field} FROM {Table}".Inject(new { PrimaryKey = pkField.Name, Field = charField.Name, Table = FullName });
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable(Name);
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int id = (int)row[pkField.Name];
                        string charValue = row[charField.Name] == DBNull.Value ? null : row[charField.Name].ToString();
                        result.Add(new KeyValuePair<int, string>(id, charValue));
                    }
                }
            }

            return result;
        }
    }
}
