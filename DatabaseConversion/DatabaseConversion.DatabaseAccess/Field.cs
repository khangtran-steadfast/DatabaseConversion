using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.DatabaseAccess
{
    public class Field
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public string DataType { get; set; }
        public bool AllowNull { get; set; }
        public bool IsVarCharMax { get; set; }
        public bool IsPrimaryKey { get; set; }
    }
}
