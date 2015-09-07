using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataConversion.DatabaseMapper.Information
{
    /// <summary>
    /// Class to store constraint information
    /// </summary>
    public class ConstraintInformation
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
        /// Constraint name
        /// </summary>
        public string ConstraintName { get; set; }

        /// <summary>
        /// Constraint type
        /// </summary>
        public string ConstraintType { get; set; }
    }
}
