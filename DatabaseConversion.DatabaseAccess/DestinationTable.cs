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
        public List<string> GetValues(string fieldName)
        {
            List<string> result = new List<string>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                Field field = GetField(fieldName);

                if(field != null)
                {
                    string query = "SELECT {Field} FROM {Table}".Inject(new { Field = field.Name, Table = FullName });
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable(Name);
                        adapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string id = row[field.Name].ToString();
                            result.Add(id);
                        }
                    }
                }
            }

            return result;
        }
    }
}
