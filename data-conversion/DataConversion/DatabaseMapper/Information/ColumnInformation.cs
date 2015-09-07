using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.Information
{
    /// <summary>
    /// Store table's column information
    /// </summary>
    public class ColumnInformation
    {
        /// <summary>
        /// Table name
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Column name
        /// </summary>
        public string ColumnName { get; set; }
        
        /// <summary>
        /// Data type
        /// </summary>
        public string DataType { get; set; }
    }
}
