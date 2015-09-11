using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DatabaseConversion.CleanerTool.Base.DatabaseMapper.Snapshot
{
    public class TableSnapshot : IEnumerator, IEnumerable
    {
        #region CONSTRUCTOR, INITIALIZE 

        /// <summary>
        /// Create table snap shot to store basic information of table
        /// </summary>
        /// <param name="tableName"></param>
        public TableSnapshot(string tableName)
        {
            this._listRecordSnapshot = new List<RecordSnapshot>();
            this._tableName = tableName;
        }

        #endregion


        #region METHODS


        /// <summary>
        /// Add new record snapshot to table
        /// </summary>
        /// <param name="record"></param>
        public void Add(RecordSnapshot record)
        {
            if (this.Contains(record) == false)
            {
                this._listRecordSnapshot.Add(record);
            }
        }

        /// <summary>
        /// Number of RecordSnapshot
        /// </summary>
        public long Count
        {
            get
            {
                return (this._listRecordSnapshot.Count);
            }
        }

        /// <summary>
        /// Is empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return (this._listRecordSnapshot.Count == 0);
            }
        }

        /// <summary>
        /// Get records
        /// With exist in both table
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static TableSnapshot GetCommonRecord(TableSnapshot first, TableSnapshot second)
        {
            //
            // Initialize result
            TableSnapshot result = new TableSnapshot(first.TableName);

            //
            // Try to compare two table snapshot
            // Get common record from both table
            foreach (RecordSnapshot record in first._listRecordSnapshot)
            {
                if (second.Contains(record))
                {
                    result.Add(record);
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Check table contains record or not
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public bool Contains(RecordSnapshot record)
        {
            return this._listRecordSnapshot.Any(x => x.Equals(record));
        }

        /// <summary>
        /// Check is duplicated unique field
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public bool IsDuplicatedUniqueColumn(RecordSnapshot record)
        {
            return this._listRecordSnapshot.Any(x => x.IsDuplicatedUniqueColumn(record));
        }
        
        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        /// <summary>
        /// Move next
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            this._currentPosition = this._currentPosition + 1;
            return (this._currentPosition < this._listRecordSnapshot.Count);
        }

        /// <summary>
        /// Reset enumerable
        /// </summary>
        public void Reset()
        {
            this._currentPosition = 0;
        }

        /// <summary>
        /// Get Current enumerable
        /// </summary>
        public object Current
        {
            get
            {
                return this._listRecordSnapshot[this._currentPosition];
            }
        }

        #endregion


        #region PROPERTIES
        

        /// <summary>
        /// Get table name
        /// </summary>
        public string TableName { get { return this._tableName; } }

        /// <summary>
        /// List record snapshots
        /// </summary>
        protected List<RecordSnapshot> _listRecordSnapshot;

        /// <summary>
        /// Table name
        /// </summary>
        protected string _tableName;

        /// <summary>
        /// Set up current postition
        /// </summary>
        protected int _currentPosition = -1;


        #endregion
    }
}
