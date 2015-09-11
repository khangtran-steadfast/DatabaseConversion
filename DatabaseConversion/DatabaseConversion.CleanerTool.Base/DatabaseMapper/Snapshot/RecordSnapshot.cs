using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DatabaseConversion.CleanerTool.Base.DatabaseMapper.Snapshot
{
    /// <summary>
    /// Contain primary key name and primary key value for record
    /// </summary>
    public class RecordSnapshot
    {
        #region CONSTRUCTOR, INITIALIZE


        /// <summary>
        /// Create record snapshot
        /// </summary>
        public RecordSnapshot()
        {
            this._listPrimaryKeySnapshot = new List<PrimaryKeySnapshot>();
            this._listGroupUniqueColumnSnapshot = new List<GroupUniqueColumnSnapshot>();
        }


        #endregion


        #region METHODS


        /// <summary>
        /// Add new primarykey snapshot (primarykey name and primarykey value)
        /// </summary>
        /// <param name="primaryKeySnapshot"></param>
        public void Add(PrimaryKeySnapshot primaryKeySnapshot)
        {
            this._listPrimaryKeySnapshot.Add(primaryKeySnapshot);
        }

        /// <summary>
        /// Add new groupuniquecolumn snapshot
        /// </summary>
        /// <param name="groupUniqueColumnSnapshot"></param>
        public void Add(GroupUniqueColumnSnapshot groupUniqueColumnSnapshot)
        {
            this._listGroupUniqueColumnSnapshot.Add(groupUniqueColumnSnapshot);
        }
        
        /// <summary>
        /// Compare two record snapshot base on primary key name and value
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
            if (obj is RecordSnapshot)
            {
                result = true;
                RecordSnapshot recordSnapshot = (RecordSnapshot)obj;
                foreach (PrimaryKeySnapshot pkSnapshot in recordSnapshot._listPrimaryKeySnapshot)
                {
                    if (this._listPrimaryKeySnapshot.Any(x => x.Equals(pkSnapshot)) == false)
                    {
                        result = false;
                        break;
                    }
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Check two record snapshot duplicated unique column or grouped unique column or not
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsDuplicatedUniqueColumn(object obj)
        {
            //
            // Initialize result
            bool result = false;
            
            //
            // Cast type
            if (obj is RecordSnapshot)
            {
                RecordSnapshot recordSnapshot = obj as RecordSnapshot;
                if (recordSnapshot.GetNumberOfGroupUniqueColumn() == this.GetNumberOfGroupUniqueColumn() && this.GetNumberOfGroupUniqueColumn() != 0)
                {
                    //
                    // If all group unique column are equal, return true (mean two record have duplicated unique field)
                    // Else return false
                    result = true;
                    foreach (GroupUniqueColumnSnapshot groupUniqueColumnSnapshot in recordSnapshot._listGroupUniqueColumnSnapshot)
                    {
                        if (this._listGroupUniqueColumnSnapshot.Any(x => x.Equals(groupUniqueColumnSnapshot)) == false)
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
        /// Override
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Return record is empty or not
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return (this._listPrimaryKeySnapshot.Count == 0);
        }

        /// <summary>
        /// Get number of primary key
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfPrimaryKey()
        {
            if (this.IsEmpty())
                return 0;
            return this._listPrimaryKeySnapshot.Count;
        }

        /// <summary>
        /// Get number of group unique column
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfGroupUniqueColumn()
        {
            return this._listGroupUniqueColumnSnapshot.Count;
        }


        #endregion


        #region PROPERTIES


        /// <summary>
        /// List primary key snapshot (primarykeyname and value)
        /// </summary>
        protected List<PrimaryKeySnapshot> _listPrimaryKeySnapshot;

        /// <summary>
        /// List GroupUniqueColumnSnapshot (contain snapshot for group unique column)
        /// </summary>
        protected List<GroupUniqueColumnSnapshot> _listGroupUniqueColumnSnapshot;


        #endregion
    }
}
