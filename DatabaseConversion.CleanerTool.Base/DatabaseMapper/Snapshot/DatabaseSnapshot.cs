using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.Information;
using FastMember;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace DatabaseConversion.CleanerTool.Base.DatabaseMapper.Snapshot
{
    public class DatabaseSnapshot : IEnumerator, IEnumerable
    {
        #region CONSTRUCTOR, INITIALIZE


        /// <summary>
        /// Create database snapshot
        /// </summary>
        /// <param name="mapDatabase"></param>
        public DatabaseSnapshot(MapDatabase mapDatabase)
        {
            this._listTableSnapshot = new List<TableSnapshot>();
            this._tableTypeReflection = new Dictionary<string, Type>();
            this._mapDatabase = mapDatabase;
            this.Initialize();
        }
        
        /// <summary>
        /// Initialize reflection between table name and table type
        /// </summary>
        protected void Initialize()
        {
            //
            // Get list of table has primary key
            List<string> listTables = this._mapDatabase.GetListTableHasPrimaryKey();
            foreach (string table in listTables)
            {
                DbSet dbSet = this._mapDatabase.GetTable(table);
                if(dbSet != null)
                {
                    dbSet.Load();
                    Type tableType = dbSet.ElementType;
                    this._tableTypeReflection.Add(table, tableType);
                }
            }
        }


        #endregion


        #region METHODS


        /// <summary>
        /// Add new TableSnapshot to database
        /// </summary>
        /// <param name="table"></param>
        public void Add(TableSnapshot table)
        {
            this._listTableSnapshot.Add(table);

        }
        
        /// <summary>
        /// Add new record to table snapshot
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="record"></param>
        public void Add(string tableName, object record)
        {
            //
            // Check
            // Are there any table in this snapshot contains tableName
            // If not, just continue
            if (this._tableTypeReflection.ContainsKey(tableName) == false)
            {
                return;
            }


            //
            // Firt, try to get record snapshot from original record
            RecordSnapshot recordSnapshot = this.GetRecordSnapshot(tableName, record);
            if (recordSnapshot == null)
            {
                return;
            }


            //
            // Then try to add to tableSnapshot
            TableSnapshot tableSnapshot = this._listTableSnapshot.FirstOrDefault(x => x.TableName.Equals(tableName));
            if (tableSnapshot == null)
            {
                tableSnapshot = new TableSnapshot(tableName);
                tableSnapshot.Add(recordSnapshot);
                this._listTableSnapshot.Add(tableSnapshot);
            }
            else
            {
                tableSnapshot.Add(recordSnapshot);
            }
        }

        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="record"></param>
        public void AddRecord(object record)
        {
            //
            // First try to get talbeName from record
            Type type = record.GetType();
            string tableName = this.GetTableName(type);
            if (tableName != null)
            {
                //
                // Check duplicated
                if (this.Contains(tableName, record) == false)
                {
                    //
                    // Ok
                    this.Add(tableName, record);
                }
            }
        }

        /// <summary>
        /// Contains record or not
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public bool Contains(object record)
        {
            //
            // Initilize result
            bool result = false;


            //
            // First try to get record type
            Type type = record.GetType();


            //
            // Then try to determinate table name base on record type
            string tableName = this.GetTableName(type);
            if (tableName != null)
            {
                result = this.Contains(tableName, record);
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Check table contains this record or not
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public bool Contains(string tableName, object record)
        {
            //
            // Initialize result
            bool result = false;


            //
            // First, try to extract main information of record
            RecordSnapshot recordSnapshot = this.GetRecordSnapshot(tableName, record);
            TableSnapshot tableSnapshot = this._listTableSnapshot.FirstOrDefault(x => x.TableName.Equals(tableName));
            if (tableSnapshot != null)
            {
                result = tableSnapshot.Contains(recordSnapshot);
                if (result == false)
                {
                    result = tableSnapshot.IsDuplicatedUniqueColumn(recordSnapshot);
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get table type by their name
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public Type GetTableType(string tableName)
        {
            //
            // Initialize result
            Type result = null;

            //
            // Get
            if (this._tableTypeReflection.ContainsKey(tableName))
            {
                result = this._tableTypeReflection[tableName];
            }

            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get table name by their type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetTableName(Type type)
        {
            //
            // Initialize result
            string result = null;

            //
            // Get
            if (this._tableTypeReflection.ContainsValue(type))
            {
                result = this._tableTypeReflection.First(x => x.Value == type).Key;
            }

            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get tablesnapshot by name
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public TableSnapshot GetTableSnapshot(string tableName)
        {
            //
            // Initialize result
            TableSnapshot result = new TableSnapshot(tableName);


            //
            // Get list of primary keys
            // For each primary key
            // Try to get it's properties in entity
            // Then add to hasTable
            DbSet dbSet = this._mapDatabase.GetTable(tableName);
            dbSet.Load();
            List<string> listPrimaryKeys = this._mapDatabase.GetPrimaryKeyName(tableName);
            List<GroupUniqueColumnInformation> listGroupUniqueInformation = this._mapDatabase.GetGroupUniqueColumnInformation(tableName);
            TypeAccessor typeAccessor = this._mapDatabase.GetTableTypeAccessor(tableName);


            //
            // Foreach record in database
            // Try to get RecordSnapshot
            foreach (object record in dbSet)
            {
                RecordSnapshot recordSnapshot = new RecordSnapshot();

                //
                // Get primary key value
                foreach (string primaryKey in listPrimaryKeys)
                {
                    PrimaryKeySnapshot primaryKeySnapshot = new PrimaryKeySnapshot(primaryKey, typeAccessor[record, primaryKey]);
                    recordSnapshot.Add(primaryKeySnapshot);
                }


                //
                // Get unqiue column value
                foreach (GroupUniqueColumnInformation groupUnique in listGroupUniqueInformation)
                {
                    GroupUniqueColumnSnapshot groupUniqueSnapshot = new GroupUniqueColumnSnapshot(groupUnique.ConstraintName);
                    foreach (UniqueColumnInformation uniqueColumnInfo in groupUnique.ListUniqueColumn)
                    {
                        UniqueColumnSnapshot uniqueColumnSnapshot = new UniqueColumnSnapshot(uniqueColumnInfo.ColumnName, typeAccessor[record, uniqueColumnInfo.ColumnName]);
                        groupUniqueSnapshot.Add(uniqueColumnSnapshot);
                    }
                    recordSnapshot.Add(groupUniqueSnapshot);
                }


                result.Add(recordSnapshot);
            }


            //
            // Return result    
            return result;
        }

        /// <summary>
        /// Get RecordShapshot from original snapshot
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public RecordSnapshot GetRecordSnapshot(string tableName, object record)
        {
            //
            // Initialize result
            RecordSnapshot result = new RecordSnapshot();


            //
            // Get list of primary keys
            // For each primary key
            // Try to get it's properties in entity
            // Then add to hasTable
            List<string> listPrimaryKeys = this._mapDatabase.GetPrimaryKeyName(tableName);
            List<GroupUniqueColumnInformation> listGroupUniqueInformation = this._mapDatabase.GetGroupUniqueColumnInformation(tableName);
            TypeAccessor typeAccessor = this._mapDatabase.GetTableTypeAccessor(tableName);


            //
            // Foreach record in database
            // Try to get RecordSnapshot
            foreach (string primaryKey in listPrimaryKeys)
            {
                PrimaryKeySnapshot primaryKeySnapshot = new PrimaryKeySnapshot(primaryKey, typeAccessor[record, primaryKey]);
                result.Add(primaryKeySnapshot);
            }


            //
            // Get unqiue column value
            foreach (GroupUniqueColumnInformation groupUnique in listGroupUniqueInformation)
            {
                GroupUniqueColumnSnapshot groupUniqueSnapshot = new GroupUniqueColumnSnapshot(groupUnique.ConstraintName);
                foreach (UniqueColumnInformation uniqueColumnInfo in groupUnique.ListUniqueColumn)
                {
                    UniqueColumnSnapshot uniqueColumnSnapshot = new UniqueColumnSnapshot(uniqueColumnInfo.ColumnName, typeAccessor[record, uniqueColumnInfo.ColumnName]);
                    groupUniqueSnapshot.Add(uniqueColumnSnapshot);
                }
                result.Add(groupUniqueSnapshot);
            }


            //
            // Return result
            return result;
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
            return (this._currentPosition < this._listTableSnapshot.Count);
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
                return this._listTableSnapshot[this._currentPosition];
            }
        }

        #endregion


        #region PROPERTIES


        /// <summary>
        /// handler to mapdatabase
        /// </summary>
        protected MapDatabase _mapDatabase;

        /// <summary>
        /// list of tablesnapshot
        /// </summary>
        protected List<TableSnapshot> _listTableSnapshot;

        /// <summary>
        /// Reflection between string and Type
        /// </summary>
        protected Dictionary<string, Type> _tableTypeReflection;

        /// <summary>
        /// Set up current postition
        /// </summary>
        protected int _currentPosition = -1;

        #endregion
    }
}
