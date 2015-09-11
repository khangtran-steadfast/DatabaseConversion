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
    public class DestinationDatabase : Database<DestinationTable>
    {
        public DestinationDatabase(string connectionString)
            : base(connectionString)
        {

        }
    }
}
