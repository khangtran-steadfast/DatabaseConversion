using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.CleanerTool.Base.DatabaseMapper.Information
{
    /// <summary>
    /// Containt group unique column information
    /// </summary>
    public class GroupUniqueColumnInformation
    {
        /// <summary>
        /// Create objec to store information about group unique column
        /// </summary>
        public GroupUniqueColumnInformation()
        {
            this._listUniqueColumn = new List<UniqueColumnInformation>();
        }

        /// <summary>
        /// Add unique column information
        /// </summary>
        /// <param name="uniqueColumn"></param>
        public void Add(UniqueColumnInformation uniqueColumn)
        {
            this._listUniqueColumn.Add(uniqueColumn);
        }

        /// <summary>
        /// Get list unique column in group
        /// </summary>
        public List<UniqueColumnInformation> ListUniqueColumn
        {
            get
            {
                return this._listUniqueColumn;
            }
        }
        
        /// <summary>
        /// Get constraint name of group unique column
        /// </summary>
        public string ConstraintName
        {
            get
            {
                string result = "";
                if (this._listUniqueColumn.Count > 0)
                {
                    result = this._listUniqueColumn.First().ConstraintName;
                }
                return result;
            }
        }

        /// <summary>
        /// List unique columns are in group
        /// </summary>
        private List<UniqueColumnInformation> _listUniqueColumn;
    }
}
