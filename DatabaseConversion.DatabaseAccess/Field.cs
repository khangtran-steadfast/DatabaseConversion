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
        public string SqlDataType { get; set; }
        public string DataType { get; set; }
        public bool AllowNull { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsUnique { get; set; }
        public int PrefixLength { get; set; }
        public int Length { get; set; }
        public string Collation { get; set; }

        public bool IsMaxDataType 
        {
            get { return DataType.Contains("max") || DataType.Contains("text"); } 
        }
    }
}
