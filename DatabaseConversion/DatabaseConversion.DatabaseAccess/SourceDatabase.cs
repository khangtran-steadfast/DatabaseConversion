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
    }
}
