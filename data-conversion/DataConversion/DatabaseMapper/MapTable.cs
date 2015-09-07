using DataConversion.DatabaseMapper.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper
{
    public class MapTable
    {
        #region CONTRUCTOR, INITIALIZE FUNCTION

        /// <summary>
        /// Default constructor, create table with specifies name
        /// </summary>
        /// <param name="name"></param>
        public MapTable(string name, bool hasPrimaryKey)
        {
            this._name = name;
            this._isMapped = false;
            this._listReference = new List<ReferenceInformation>();
            this._hasPrimaryKey = hasPrimaryKey;
        }

        #endregion


        #region METHODS


        /// <summary>
        /// Add reference
        /// </summary>
        /// <param name="table"></param>
        public void AddReference(ReferenceInformation reference)
        {
            this._listReference.Add(reference);
        }

        /// <summary>
        /// Add new references
        /// </summary>
        /// <param name="listReferences"></param>
        public void AddReference(List<ReferenceInformation> listReferences)
        {
            this._listReference.AddRange(listReferences);
        }

        /// <summary>
        /// Set this table is mapped
        /// </summary>
        public void Map()
        {
            this._isMapped = true;
        }

        /// <summary>
        /// Does this table have any reference ?
        /// </summary>
        /// <returns></returns>
        public bool HasReference()
        {
            return (this._listReference.Count != 0);
        }

        /// <summary>
        /// Does this table have reference to "reference" table ?
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public bool HasReference(MapTable table)
        {
            //
            // Initialize result
            bool result = false;
            

            //
            // Check
            foreach (ReferenceInformation reference in this._listReference)
            {
                if (reference.PKTableName.Equals(table.Name))
                {
                    result = true;
                    break;
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Does this table have referenced to "tableName" table ?
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool HasReference(string tableName)
        {
            //
            // Initialize result flag
            bool result = false;
            

            //
            // Check
            foreach (ReferenceInformation reference in this._listReference)
            {
                if (reference.PKTableName.Equals(tableName))
                {
                    result = true;
                    break;
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Check this table has this reference or not
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public bool HasReference(ReferenceInformation reference)
        {
            //
            // Initialize result
            bool result = false;

            //
            // Check
            foreach (ReferenceInformation refer in this._listReference)
            {
                if (refer.Equals(reference))
                {
                    result = true;
                    break;
                }
            }

            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get list of reference
        /// </summary>
        /// <returns></returns>
        public List<ReferenceInformation> GetReference()
        {
            return this._listReference;
        }

        /// <summary>
        /// Get reference information
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<ReferenceInformation> GetReference(MapTable table)
        {
            return this._listReference.Where(x => x.PKTableName.Equals(table.Name)).ToList();
        }

        /// <summary>
        /// Get reference information
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<ReferenceInformation> GetReference(string table)
        {
            return this._listReference.Where(x => x.PKTableName.Equals(table)).ToList();
        }
        
        /// <summary>
        /// Remove reference
        /// </summary>
        /// <param name="reference"></param>
        public void RemoveReference(ReferenceInformation reference)
        {
            this._listReference.Remove(reference);
        }

        /// <summary>
        /// Remove weak reference
        /// </summary>
        public void RemoveWeakReference()
        {
            this._listReference.RemoveAll(x => x.IsWeakReference);
        }


        #endregion


        #region PROPERTIES


        /// <summary>
        /// Table name
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }
        }

        /// <summary>
        /// Number of reference
        /// </summary>
        public int NumberOfReference
        {
            get
            {
                return this._listReference.Count;
            }
        }

        /// <summary>
        /// Determinate this table has primary key or not
        /// </summary>
        public bool HasPrimaryKey
        {
            get
            {
                return this._hasPrimaryKey;
            }
        }

        /// <summary>
        /// Is mapped yet ?
        /// </summary>
        public bool IsMapped
        {
            get
            {
                return this._isMapped;
            }
        }

        /// <summary>
        /// Name of table
        /// </summary>
        protected string _name;

        /// <summary>
        /// Is mapped yet ?
        /// </summary>
        protected bool _isMapped;

        /// <summary>
        /// List of references
        /// </summary>
        protected List<ReferenceInformation> _listReference;

        /// <summary>
        /// Determinate table has primary key or not
        /// </summary>
        protected bool _hasPrimaryKey;


        #endregion
    }
}
