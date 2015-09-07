using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataConversion.DatabaseMapper.Snapshot
{
    /// <summary>
    /// Class contains name and value of unique column
    /// </summary>
    public class UniqueColumnSnapshot
    {
        /// <summary>
        /// Create new snapshot for unique column
        /// </summary>
        /// <param name="name">Column name</param>
        /// <param name="value">Column value</param>
        public UniqueColumnSnapshot(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Override GetHashCode of object class
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Override Equals
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
            if (obj is UniqueColumnSnapshot)
            {
                UniqueColumnSnapshot uniqueColumn = (UniqueColumnSnapshot)obj;
                if (uniqueColumn.Name.Equals(this.Name))
                {
                    if (uniqueColumn.Value != null && uniqueColumn.Value.Equals(this.Value))
                    {
                        result = true;
                    }
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Column name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of unique column
        /// </summary>
        public object Value { get; set; }
    }
}
