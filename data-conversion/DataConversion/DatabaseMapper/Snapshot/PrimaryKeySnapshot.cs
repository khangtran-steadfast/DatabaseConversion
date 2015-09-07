using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataConversion.DatabaseMapper.Snapshot
{
    public class PrimaryKeySnapshot
    {
        public PrimaryKeySnapshot(string primaryKeyName, object primaryKeyValue)
        {
            this.Name = primaryKeyName;
            this.Value = primaryKeyValue;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            //
            // Initialize result
            bool result = false;


            //
            // Check
            if (obj is PrimaryKeySnapshot)
            {
                PrimaryKeySnapshot pkSnapshot = (PrimaryKeySnapshot)obj;
                if (pkSnapshot.Name == this.Name && pkSnapshot.Value.Equals(this.Value))
                {
                    result = true;
                }
            }

            //
            // Return result
            return result;
        }

        public string Name { get; set; }

        public object Value { get; set; }
    }
}