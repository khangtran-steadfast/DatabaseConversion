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
    public class DestinationTable : Table
    {
        public List<int> GetIds()
        {
            List<int> result = new List<int>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Field pkField = GetPrimaryKey();

                string query = "SELECT {PrimaryKey} FROM {Table}".Inject(new { PrimaryKey = pkField.Name, Table = FullName });
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable(Name);
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int id = (int)row[pkField.Name];
                        result.Add(id);
                    }
                }
            }

            return result;
        }
    }
}
