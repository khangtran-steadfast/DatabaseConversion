using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.MapperReport
{
    public class MapperReportDatabase
    {
        #region CONSTRUCTOR, INITIALIZE

        /// <summary>
        /// Create report for database mapping
        /// </summary>
        public MapperReportDatabase(string sourceDatabaseName, string destDatabaseName)
        {
            this._sourceDatabaseName = sourceDatabaseName;
            this._destinationDatabaseName = destDatabaseName;
            this._listReportTable = new List<MapperReportTable>();
        }

        #endregion
        

        #region METHODS

        /// <summary>
        /// Add table mapping exception message
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="exceptionMessage"></param>
        public void AddException(string tableName, string exceptionMessage)
        {
            MapperReportTable table = this._listReportTable.First(x => x.TableName.Equals(tableName));
            if (table != null)
            {
                table.AddException(exceptionMessage);
            }
        }

        /// <summary>
        /// Add log about mapping successfull for single record
        /// </summary>
        /// <param name="tableName"></param>
        public void AddSuccessRecord(string tableName)
        {
            MapperReportTable table = this._listReportTable.First(x => x.TableName.Equals(tableName));
            if (table != null)
            {
                table.AddSuccessRecords();
            }
        }

        /// <summary>
        /// Add existed record log
        /// </summary>
        /// <param name="tableName"></param>
        public void AddExistedRecord(string tableName)
        {
            MapperReportTable table = this._listReportTable.First(x => x.TableName.Equals(tableName));
            if (table != null)
            {
                table.AddExistedRecord();
            }
        }

        /// <summary>
        /// Create new report for table mapping
        /// </summary>
        /// <param name="tableName"></param>
        public void CreateReportTable(string tableName)
        {
            if (this._listReportTable.Any(x => x.TableName.Equals(tableName)) == false)
            {
                this._listReportTable.Add(new MapperReportTable(tableName));
            }
        }

        /// <summary>
        /// Get current status of mapping database
        /// </summary>
        /// <returns></returns>
        public string GetStatus()
        {
            //
            // Initialize result
            string result = "Success";

            //
            // Check
            foreach(MapperReportTable table in this._listReportTable)
            {
                if (table.IsSuccess == false)
                {
                    result = "Failed";
                    break;
                }
            }
            if (result.Equals("Success") && this._listReportTable.Count < this._totalTable)
            {
                result = "Running";
            }
            

            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get report table
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public MapperReportTable GetReportTable(string table)
        {
            return this._listReportTable.First(x => x.TableName.Equals(table));
        }

        /// <summary>
        /// Set starting time
        /// </summary>
        public void StartMap()
        {
            this._startTime = DateTime.Now;
        }

        /// <summary>
        /// Set start mapping time
        /// </summary>
        /// <param name="tableName"></param>
        public void StartMap(string tableName)
        {
            MapperReportTable table = this._listReportTable.FirstOrDefault(x => x.TableName.Equals(tableName));
            if (tableName != null)
            {
                table.StartMap();
            }
        }
                
        /// <summary>
        /// Set total table
        /// </summary>
        /// <param name="totalTable"></param>
        public void SetTotalTable(int totalTable)
        {
            this._totalTable = totalTable;
        }

        /// <summary>
        /// Set end mapping time
        /// </summary>
        public void EndMap()
        {
            this._endTime = DateTime.Now;
        }

        /// <summary>
        /// Mapping table completed
        /// </summary>
        /// <param name="tableName"></param>
        public void EndMap(string tableName)
        {
            MapperReportTable table = this._listReportTable.FirstOrDefault(x => x.TableName.Equals(tableName));
            if (tableName != null)
            {
                table.EndMap();
            }
        }


        #endregion


        #region PROPERTIES

        /// <summary>
        /// Get list report of table
        /// </summary>
        public List<MapperReportTable> ListReportTable
        {
            get
            {
                return this._listReportTable;
            }
        }

        /// <summary>
        /// Get number of total tables to map
        /// </summary>
        public int NumberOfTotalTable
        {
            get
            {
                return this._totalTable;
            }
        }

        /// <summary>
        /// Get number of table has been mapped successfull
        /// </summary>
        public int NumberOfSuccessTable
        {
            get
            {
                int counter = 0;
                foreach (MapperReportTable table in this._listReportTable)
                {
                    if (table.IsSuccess)
                    {
                        counter = counter + 1;
                    }
                }
                return counter;
            }
        }

        /// <summary>
        /// Get number of mapping failed
        /// </summary>
        public int NumberOfFailedTable
        {
            get
            {
                int counter = 0;
                foreach (MapperReportTable table in this._listReportTable)
                {
                    if (table.IsSuccess == false)
                    {
                        counter = counter + 1;
                    }
                }
                return counter;
            }
        }

        /// <summary>
        /// Start mapping time
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return this._startTime;
            }
        }

        /// <summary>
        /// Get running time to map between two database
        /// </summary>
        public double RunningTime
        {
            get
            {
                this._endTime = DateTime.Now;
                return Math.Abs((this._endTime - this._startTime).TotalSeconds);
            }
        }
        
        /// <summary>
        /// Source database name
        /// </summary>
        public string SourceDatabaseName
        {
            get
            {
                return this._sourceDatabaseName;
            }
        }

        /// <summary>
        /// Destination database name
        /// </summary>
        public string DestinationDatabaseName
        {
            get
            {
                return this._destinationDatabaseName;
            }
        }

        /// <summary>
        /// Source database name
        /// </summary>
        protected string _sourceDatabaseName;

        /// <summary>
        /// Destination database name
        /// </summary>
        protected string _destinationDatabaseName;

        /// <summary>
        /// Start time
        /// </summary>
        protected DateTime _startTime;

        /// <summary>
        /// End time
        /// </summary>
        protected DateTime _endTime;

        /// <summary>
        /// Total tables
        /// </summary>
        protected int _totalTable;

        /// <summary>
        /// Number of tables which completed mapping
        /// </summary>
        protected int _successTable;

        /// <summary>
        /// Number of tables which failed mapping
        /// </summary>
        protected int _failedTable;
        
        /// <summary>
        /// List report for table
        /// </summary>
        protected List<MapperReportTable> _listReportTable;

        #endregion
    }
}
