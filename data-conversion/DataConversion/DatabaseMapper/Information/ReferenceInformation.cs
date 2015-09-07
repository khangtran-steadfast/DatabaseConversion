using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.Information
{
    public class ReferenceInformation
    {
        /// <summary>
        /// Determinate two reference is equal or not
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //
            // Initialize result
            bool result = false;


            //
            // Check
            if (obj is ReferenceInformation)
            {
                ReferenceInformation refer = obj as ReferenceInformation;
                if (this.PKTableName.Equals(refer.PKTableName) &&
                   this.PKColumnName.Equals(refer.PKColumnName) &&
                   this.FKTableName.Equals(refer.FKTableName) &&
                   this.FKColumnName.Equals(refer.FKColumnName))
                {
                    result = true;
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Override get hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Primary key table name
        /// </summary>
        public string PKTableName { get; set; }

        /// <summary>
        /// Primary key column name
        /// </summary>
        public string PKColumnName { get; set; }

        /// <summary>
        /// Foreign key table name
        /// </summary>
        public string FKTableName { get; set; }

        /// <summary>
        /// Foreign Key Column name
        /// </summary>
        public string FKColumnName { get; set; }

        /// <summary>
        /// Constraint name
        /// </summary>
        public string ConstraintName { get; set; }

        /// <summary>
        /// Determinate which reference is weak reference
        /// Weak reference is reference, which reference column allow null value
        /// </summary>
        [System.ComponentModel.DefaultValue(false)]
        public bool IsWeakReference { get; set; }
    }
}
