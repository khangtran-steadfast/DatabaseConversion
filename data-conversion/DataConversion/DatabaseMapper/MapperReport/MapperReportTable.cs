using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.MapperReport
{
    /// <summary>
    /// Class for export migration report
    /// </summary>
    public class MapperReportTable
    {
        #region CONSTRUCTOR, INITIALIZE

        /// <summary>
        /// Create new report for table
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="totalRecords"></param>
        public MapperReportTable(string tableName, int totalRecords)
        {
            this._tableName = tableName;
            this._totalRecords = totalRecords;
            this._listException = new List<string>();
            this._successRecords = 0;
            this._alreadyExisted = 0;
            this.IsExported = false;
        }

        /// <summary>
        /// Create new report for table
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="totalRecords"></param>
        public MapperReportTable(string tableName)
        {
            this._tableName = tableName;
            this._totalRecords = 0;
            this._listException = new List<string>();
            this._successRecords = 0;
            this._alreadyExisted = 0;
            this.IsExported = false;
        }

        #endregion


        #region METHODS

        /// <summary>
        /// Add exception message to list
        /// </summary>
        /// <param name="exceptionMessage"></param>
        public void AddException(string exceptionMessage)
        {
            this._listException.Add(exceptionMessage);
        }

        /// <summary>
        /// Add new record
        /// </summary>
        public void AddSuccessRecords()
        {
            this._successRecords = this._successRecords + 1;
        }

        /// <summary>
        /// Add existed records
        /// </summary>
        public void AddExistedRecord()
        {
            this._alreadyExisted = this._alreadyExisted + 1;
        }

        /// <summary>
        /// Get mapping status
        /// </summary>
        /// <returns></returns>
        public string GetStatus()
        {
            if (this._listException.Count == 0)
                return "Success";
            return "Failed";
        }

        /// <summary>
        /// Start map
        /// </summary>
        public void StartMap()
        {
            this._startTime = DateTime.Now;
        }

        /// <summary>
        /// Set total records
        /// </summary>
        /// <param name="totalRecords"></param>
        public void SetTotalRecords(int totalRecords)
        {
            this._totalRecords = totalRecords;
        }

        /// <summary>
        /// End map
        /// </summary>
        public void EndMap()
        {
            this._endTime = DateTime.Now;
        }

        #endregion
        

        #region PROPERTIES

        /// <summary>
        /// Get number of record, which is already existed in destination database
        /// </summary>
        public int NumberOfAlreadyExisted
        {
            get
            {
                return this._alreadyExisted;
            }
        }

        /// <summary>
        /// Get number of records, which have mapped failed
        /// </summary>
        public int NumberOfErrors
        {
            get
            {
                return this._listException.Count;
            }
        }

        /// <summary>
        /// Number of records has been mapped successfull
        /// </summary>
        public int NumberOfSuccess
        {
            get
            {
                return this._successRecords;
            }
        }

        /// <summary>
        /// Get total record of table
        /// </summary>
        public int TotalRecord
        {
            get
            {
                return this._totalRecords;
            }
        }

        /// <summary>
        /// Get start mapping time
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return this._startTime;
            }
        }

        /// <summary>
        /// Get end time
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return this._endTime;
            }
        }

        /// <summary>
        /// Get running time to map this table
        /// </summary>
        public double RunningTime
        {
            get
            {
                if (this._startTime == null || this._endTime == null)
                {
                    return 0;
                }
                return (this._endTime - this._startTime).TotalSeconds;
            }
        }

        /// <summary>
        /// Get list of exception messages
        /// </summary>
        public List<string> ExceptionMessages
        {
            get
            {
                return this._listException;
            }
        }

        /// <summary>
        /// Check mapping table is success or failed
        /// </summary>
        /// <returns></returns>
        public bool IsSuccess
        {
            get
            {
                return (this._listException.Count == 0);
            }
        }

        /// <summary>
        /// Get table name
        /// </summary>
        public string TableName
        {
            get
            {
                return this._tableName;
            }
        }

        /// <summary>
        /// Is exported yet ?
        /// </summary>
        public bool IsExported { get; set; }

        /// <summary>
        /// Table Name
        /// </summary>
        protected string _tableName;

        /// <summary>
        /// Time start mapping
        /// </summary>
        protected DateTime _startTime;

        /// <summary>
        /// End mapping
        /// </summary>
        protected DateTime _endTime;

        /// <summary>
        /// Total record to map
        /// </summary>
        protected int _totalRecords;

        /// <summary>
        /// Number of existed records
        /// </summary>
        protected int _alreadyExisted;

        /// <summary>
        /// New added records
        /// </summary>
        protected int _successRecords;

        /// <summary>
        /// List exception
        /// </summary>
        protected List<string> _listException;

        #endregion
    }
}
