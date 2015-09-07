using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.Snapshot
{
    /// <summary>
    /// Class stores snapshot of group unique column
    /// </summary>
    public class GroupUniqueColumnSnapshot
    {
        /// <summary>
        /// Create new gruop unique colum snapshot
        /// </summary>
        /// <param name="constraintName"></param>
        public GroupUniqueColumnSnapshot(string constraintName)
        {
            this._listUniqueColumnSnapshot = new List<UniqueColumnSnapshot>();
            this._constraintName = constraintName;
        }

        /// <summary>
        /// Add unique column snapshot to list snapshot
        /// </summary>
        /// <param name="uniqueColumnSnapshot"></param>
        public void Add(UniqueColumnSnapshot uniqueColumnSnapshot)
        {
            this._listUniqueColumnSnapshot.Add(uniqueColumnSnapshot);
        }

        /// <summary>
        /// Determinate two group unique column equal or not
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //
            // Initialize result
            bool result = false;


            //
            // Cast type and check
            if (obj is GroupUniqueColumnSnapshot)
            {
                GroupUniqueColumnSnapshot groupUniqueColumn = obj as GroupUniqueColumnSnapshot;
                if (groupUniqueColumn.ConstraintName.Equals(this._constraintName) && groupUniqueColumn.NumberOfUniqueColumn == this.NumberOfUniqueColumn)
                {

                    //
                    // Make sure, all of unqiue column are equal
                    // If only one unique column is different
                    // Return false immediately
                    result = true;
                    foreach (UniqueColumnSnapshot uniqueColumn in groupUniqueColumn._listUniqueColumnSnapshot)
                    {
                        if (this._listUniqueColumnSnapshot.Any(x => x.Equals(uniqueColumn)) == false)
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            

            //
            // Return result
            return result;
        }

        /// <summary>
        /// Override base class
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        /// <summary>
        /// Constraint name
        /// </summary>
        public string ConstraintName
        {
            get
            {
                return this._constraintName;
            }
        }

        /// <summary>
        /// Get number of unique column in group
        /// </summary>
        public int NumberOfUniqueColumn
        {
            get
            {
                return this._listUniqueColumnSnapshot.Count;
            }
        }

        /// <summary>
        /// Group unique constraint name
        /// </summary>
        private string _constraintName;

        /// <summary>
        /// List unique column snapshot
        /// </summary>
        private List<UniqueColumnSnapshot> _listUniqueColumnSnapshot;
    }
}
