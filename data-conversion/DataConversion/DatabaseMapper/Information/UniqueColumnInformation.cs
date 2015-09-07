using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.Information
{
    /// <summary>
    /// Class to store unqiue column information
    /// </summary>
    public class UniqueColumnInformation : ConstraintInformation
    {
        /// <summary>
        /// Create new object to store unqiue column information
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <param name="constraintName"></param>
        public UniqueColumnInformation(string tableName, string columnName, string constraintName) : base()
        {
            this.TableName = tableName;
            this.ColumnName = columnName;
            this.ConstraintName = constraintName;
            this.ConstraintType = "UNIQUE";
        }

        /// <summary>
        /// Create new object to store unique column information
        /// </summary>
        /// <param name="constraintInformation"></param>
        public UniqueColumnInformation(ConstraintInformation constraintInformation) : base()
        {
            if (constraintInformation.ConstraintType.Equals("Unique") ||
               constraintInformation.ConstraintType.Equals("UNIQUE"))
            {
                this.TableName = constraintInformation.TableName;
                this.ColumnName = constraintInformation.ColumnName;
                this.ConstraintName = constraintInformation.ConstraintName;
                this.ConstraintType = "UNIQUE";
            }
        }
    }
}
