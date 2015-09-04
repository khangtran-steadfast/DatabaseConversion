using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
