using AutoMapper;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.Information;
using FastMember;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper
{
    public abstract class MapDatabase
    {
        #region CONSTRUCTOR, INITIALIZE


        /// <summary>
        /// Create map database
        /// </summary>
        /// <param name="dbContextType"></param>
        public MapDatabase(Type dbContextType)
        {
            this._listTable = new List<MapTable>();
            this._dbContextType = dbContextType;
        }

        /// <summary>
        /// Initialize
        /// </summary>
        protected void Initialize()
        {
            //
            // 1) Get list table
            // Create list MapTable
            LogService.Log.Info("Getting list tables.");
            this._dbContext.Configuration.LazyLoadingEnabled = false;
            this._dbContext.Configuration.ProxyCreationEnabled = false;
            this._dbContext.Configuration.AutoDetectChangesEnabled = false;
            this._dbContext.Configuration.ValidateOnSaveEnabled = false;
            List<string> listTableName = this.GetListTable();


            //
            // 2) Initialize for primary key list
            LogService.Log.Info("Getting table's primary key.");
            this.InitializeListPrimaryKey(listTableName);

            //
            // 3) Get unqiue column information
            LogService.Log.Info("Get unique column information.");
            this.InitializeListUniqueColumn(listTableName);

            //
            // 4) Foreach table
            // Add referenced table to their list
            LogService.Log.Info("Getting references between table.");
            this.InitializeListReference();

            //
            // 5) Initialize table column
            // to access list column of table (name) faster
            LogService.Log.Info("Getting table's schema.");
            this.InitializeTableColumn(listTableName);

            //
            // 6) Initialize for hashtable
            // This allow us to get DbSet through their name
            // Then try to get DbSet properties to access table's column faster
            LogService.Log.Info("Getting DbSet from DbContext.");
            this.InitializeListTableProperties(listTableName);

            //
            // 7) Initialize for type accessor (member of FastMember library)
            // for better performance (better than .NET Reflection)
            LogService.Log.Info("Getting TypeAccessor (FastMember library) to access table properties.");
            this.InitializeListTableTypeAccessor(listTableName);
        }

        /// <summary>
        /// Initialize for list table column
        /// </summary>
        /// <param name="listTableName"></param>
        private void InitializeTableColumn(List<string> listTableName)
        {
            this._listTableColumn = new Dictionary<string, List<ColumnInformation>>();
            foreach (string tableName in listTableName)
            {
                this._listTableColumn.Add(tableName, this.GetTableColumnBySQLScript(tableName));
            }
        }

        /// <summary>
        /// Initialize for list map table
        /// </summary>
        private void InitializeListReference()
        {
            Dictionary<string, List<ReferenceInformation>> listReferences = this.GetListReferenceBySQLScript();
            foreach (MapTable table in this._listTable)
            {
                if (listReferences.ContainsKey(table.Name))
                {
                    table.AddReference(listReferences[table.Name]);
                }
            }
        }

        /// <summary>
        /// Initialize list table properties
        /// </summary>
        /// <param name="listTableName"></param>
        private void InitializeListTableProperties(List<string> listTableName)
        {
            this._listDbSet = new Hashtable();
            foreach (string tableName in listTableName)
            {
                Type entityType = this._dbContextType.Assembly.GetType(this._dbContextType.Namespace + "." + tableName);
                if (entityType == null)
                {
                    continue;
                }

                //
                // If not null try to get DbSet
                DbSet dbSet = this._dbContext.Set(entityType);
                if (dbSet != null)
                {
                    this._listDbSet.Add(tableName, dbSet);
                }
            }
        }

        /// <summary>
        /// Initialize list primary key
        /// </summary>
        /// <param name="listTableName"></param>
        private void InitializeListPrimaryKey(List<string> listTableName)
        {
            //
            // Initialize
            this._listTablePrimaryKeyName = new Dictionary<string, List<string>>();


            //
            // Try to get primary key information for each table
            foreach (string table in listTableName)
            {
                try
                {
                    string sqlQuery = @"SELECT column_name 
                                        FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
                                        WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1
                                        AND table_name = '" + table + "'";
                    List<string> pks = this._dbContext.Database.SqlQuery<string>(sqlQuery).ToList();
                    this._listTablePrimaryKeyName.Add(table, pks);


                    //
                    // Add new table
                    if (pks.Count > 0)
                    {
                        MapTable mapTable = new MapTable(table, true);
                        this._listTable.Add(mapTable);
                    }
                    else
                    {
                        MapTable mapTable = new MapTable(table, false);
                        this._listTable.Add(mapTable);
                    }
                }
                catch (Exception exc)
                {
                    LogService.Log.Error("Can not get primary key list from table.", exc);
                }
            }
        }

        /// <summary>
        /// Initialize for list unique column
        /// </summary>
        /// <param name="listTableName"></param>
        private void InitializeListUniqueColumn(List<string> listTableName)
        {
            //
            // Intialize
            this._listGroupUniqueColumn = new Dictionary<string, List<GroupUniqueColumnInformation>>();

            
            //
            // Get list unique constraint
            List<ConstraintInformation> listConstraints = this.GetListConstraintByType("UNIQUE");


            //
            // Initialize memory space for all table
            // To store unique column information
            foreach (string table in listTableName)
            {
                this._listGroupUniqueColumn.Add(table, new List<GroupUniqueColumnInformation>());
            }


            //
            // Then for each unique constraint
            // Move them to right place to store
            foreach (ConstraintInformation constraintInformation in listConstraints)
            {
                UniqueColumnInformation uniqueColumn = new UniqueColumnInformation(constraintInformation);
                List<GroupUniqueColumnInformation> groupUniqueColumn = this._listGroupUniqueColumn[uniqueColumn.TableName];
                
                //
                // If already has group unique column for this
                // Just add
                // Else, create new and add to list
                if (groupUniqueColumn.Any(x => x.ConstraintName.Equals(uniqueColumn.ConstraintName)))
                {
                    groupUniqueColumn.First(x => x.ConstraintName.Equals(uniqueColumn.ConstraintName)).Add(uniqueColumn);
                }
                else
                {
                    GroupUniqueColumnInformation newGroup = new GroupUniqueColumnInformation();
                    newGroup.Add(uniqueColumn);
                    groupUniqueColumn.Add(newGroup);
                }
            }
        }
        
        /// <summary>
        /// Initialize for List Table Type Accessor dictionary
        /// </summary>
        /// <param name="listTableName"></param>
        private void InitializeListTableTypeAccessor(List<string> listTableName)
        {
            this._listTableTypeAccessor = new Hashtable();
            foreach(string table in listTableName)
            {
                DbSet dbSet = this.GetTable(table);
                if (dbSet == null)
                {
                    continue;
                }


                //
                // If not null
                // Get type and extract type accessor
                Type elementType = dbSet.ElementType;
                TypeAccessor typeAccessor = TypeAccessor.Create(elementType);
                this._listTableTypeAccessor.Add(table, typeAccessor);
            }
        }


        #endregion


        #region METHODS


        /// <summary>
        /// Add new table
        /// </summary>
        /// <param name="table"></param>
        public void AddTable(MapTable table)
        {
            this._listTable.Add(table);
        }

        /// <summary>
        /// Get list of table, which has circle reference
        /// </summary>
        /// <returns></returns>
        public List<string> DetectCircleReference()
        {
            //
            // Initialize result
            List<string> result = new List<string>();


            //
            // Check
            List<string> listTable = this.GetListTable();
            foreach (string table in listTable)
            {
                if (this.HasCircleReference(table))
                {
                    result.Add(table);
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Dont map this table
        /// </summary>
        /// <param name="tableName"></param>
        public void IgnoreTable(string tableName)
        {
            MapTable table = this.GetMapTable(tableName);
            if (table != null)
            {
                table.Map();
            }
        }

        /// <summary>
        /// Get primary key value and parse to string
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetPrimaryKeyValue(string tableName, object record)
        {
            //
            // Initialize result
            Dictionary<string, object> result = new Dictionary<string, object>();


            //
            // Get primary key name first
            List<string> listPrimaryKey = this.GetPrimaryKeyName(tableName);
            TypeAccessor typeAccessor = this.GetTableTypeAccessor(tableName);


            //
            // Check
            if (listPrimaryKey.Count == 0 || typeAccessor == null)
            {
                return result;
            }


            //
            // Extract value
            foreach (string primaryKey in listPrimaryKey)
            {
                try
                {
                    object primaryKeyValue = typeAccessor[record, primaryKey];
                    result.Add(primaryKey, primaryKeyValue);
                }
                catch (Exception excGetPrimaryKeyValue)
                {
                    LogService.Log.Error("Can not get primary key value of table " + tableName, excGetPrimaryKeyValue);
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get DbContext of database
        /// </summary>
        /// <returns></returns>
        public DbContext GetDbContext()
        {
            return this._dbContext;
        }

        /// <summary>
        /// Get database name
        /// </summary>
        /// <returns></returns>
        public string GetDatabaseName()
        {
            //
            // Initialize result
            string result = "";

            try
            {
                result = this._dbContext.Database.SqlQuery<string>("SELECT DB_NAME() AS DataBaseName").First();
            }
            catch (Exception exc)
            {
                LogService.Log.Error("Can not get database name.", exc);
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get table type accessor
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public TypeAccessor GetTableTypeAccessor(string tableName)
        {
            //
            // Initialize result
            TypeAccessor result = null;


            //
            // Get
            if (this._listTableTypeAccessor.Contains(tableName))
            {
                result = (TypeAccessor)this._listTableTypeAccessor[tableName];
            }

            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get table DbSet by name
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public virtual DbSet GetTable(string tableName)
        {
            //
            // Initialize result
            DbSet result = null;

            //
            // Get DbSet
            if (this._listDbSet.ContainsKey(tableName))
            {
                result = (DbSet)this._listDbSet[tableName];
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get new db context
        /// </summary>
        /// <returns></returns>
        public abstract DbContext GetNewDbContext();
        
        /// <summary>
        /// Get MapTable type by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MapTable GetMapTable(string name)
        {
            foreach (MapTable table in this._listTable)
                if (string.Equals(table.Name, name))
                    return table;
            return null;
        }

        /// <summary>
        /// Get list table's name in database
        /// </summary>
        /// <returns></returns>
        public List<string> GetListTable()
        {
            return this._dbContext.Database.SqlQuery<string>(@"SELECT name FROM sys.Tables").ToList();
        }

        /// <summary>
        /// Get table's column name by SQL Script
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private List<ColumnInformation> GetTableColumnBySQLScript(string tableName)
        {
            //
            // Initialize result
            List<ColumnInformation> result = new List<ColumnInformation>();

            //
            // Try to exec SQL Query
            try
            {
                string sqlQuery = @"SELECT COLUMN_NAME AS ColumnName, DATA_TYPE AS DataType
                                    FROM INFORMATION_SCHEMA.COLUMNS
                                    WHERE TABLE_NAME='" + tableName + "'";
                List<ColumnInformation> response = this._dbContext.Database.SqlQuery<ColumnInformation>(sqlQuery).ToList();
                if (response != null && response.Count > 0)
                {
                    result = response;
                }

            }
            catch (Exception exc)
            {
                LogService.Log.Error("Can not get table information.", exc);
            }

            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get table column's name
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<ColumnInformation> GetTableColumn(string tableName)
        {
            //
            // Initialize result
            List<ColumnInformation> result = new List<ColumnInformation>();

            //
            // Get result from dictionary
            if (this._listTableColumn.ContainsKey(tableName))
            {
                result = this._listTableColumn[tableName];
            }

            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get list table has primary key
        /// </summary>
        /// <returns></returns>
        public List<string> GetListTableHasPrimaryKey()
        {
            List<string> result = this._dbContext.Database.SqlQuery<string>(@"SELECT name AS TableName
                                                               FROM sys.tables
                                                               WHERE OBJECTPROPERTY(OBJECT_ID,'TableHasPrimaryKey') = 1
                                                               ORDER BY TableName").ToList();
            result.Remove("sysdiagrams");
            return result;
        }

        /// <summary>
        /// Get list reference of table
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<ReferenceInformation> GetListReference(string tableName)
        {
            //
            // Initialize result
            List<ReferenceInformation> result = new List<ReferenceInformation>();

            //
            // Get list reference
            MapTable table = this.GetMapTable(tableName);
            if (table != null)
            {
                result = table.GetReference();
            }

            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get list constraint information by type
        /// </summary>
        /// <returns></returns>
        private List<ConstraintInformation> GetListConstraintByType(string constraintType)
        {
            //
            // Initialize result
            List<ConstraintInformation> result = new List<ConstraintInformation>();


            //
            // Exec sql script
            try
            {
                string sqlQuery = @"SELECT TC.TABLE_NAME AS TableName, COLUMN_NAME AS ColumnName, TC.CONSTRAINT_NAME AS ConstraintName, TC.CONSTRAINT_TYPE AS ConstraintType
                                    FROM information_schema.table_constraints TC
                                    INNER JOIN information_schema.constraint_column_usage CC ON TC.Constraint_Name = CC.Constraint_Name
                                    WHERE TC.constraint_type = '{CONSTRAINT_TYPE}'
                                    ORDER BY TC.TABLE_NAME, TC.CONSTRAINT_NAME";
                List<ConstraintInformation> response = this._dbContext.Database.SqlQuery<ConstraintInformation>(sqlQuery.Replace("{CONSTRAINT_TYPE}", constraintType)).ToList();
                if (response != null && response.Count > 0)
                {
                    result = response;
                }
            }
            catch (Exception exc)
            {
                LogService.Log.Error("Can not invoke SQL script to get constraint information.", exc);
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get group unique column information
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<GroupUniqueColumnInformation> GetGroupUniqueColumnInformation(string tableName)
        {
            //
            // Initialize result
            List<GroupUniqueColumnInformation> result = new List<GroupUniqueColumnInformation>();

            //
            // Check and get
            if (this._listGroupUniqueColumn.ContainsKey(tableName))
            {
                result = this._listGroupUniqueColumn[tableName];
            }

            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get list reference of table through sql script
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private List<ReferenceInformation> GetListReferenceBySQLScript(string tableName)
        {
            //
            // Initialize result
            List<ReferenceInformation> result = new List<ReferenceInformation>();


            //
            // Try to invoke db
            try
            {
                //
                // First try to get information about reference
                // (From this table, reference to another table)
                string sqlQuery = @"SELECT
                                    FKTableName = FK.TABLE_NAME,
                                    FKColumnName = CU.COLUMN_NAME,
                                    PKTableName = PK.TABLE_NAME,
                                    PKColumnName = PT.COLUMN_NAME,
                                    ConstraintName = C.CONSTRAINT_NAME
                                FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
                                    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
                                    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
                                    INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
                                    INNER JOIN (
                                        SELECT i1.TABLE_NAME, i2.COLUMN_NAME
                                        FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                                        INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                                        WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                                    ) PT ON PT.TABLE_NAME = PK.TABLE_NAME
                                WHERE FK.TABLE_NAME = '" + tableName + "'";
                List<ReferenceInformation> response = this._dbContext.Database.SqlQuery<ReferenceInformation>(sqlQuery).ToList();



                //
                // Then try to determinate
                // which reference is weak reference
                // Weak reference is reference, which reference table's column allow nulls value
                string queryTemplate = @"SELECT IS_NULLABLE
                                         FROM INFORMATION_SCHEMA.COLUMNS 
                                         WHERE TABLE_NAME ='FKTableName' and COLUMN_NAME ='FKColumnName'";
                foreach (ReferenceInformation reference in response)
                {
                    string query = queryTemplate.Replace("FKTableName", reference.FKTableName)
                                                .Replace("FKColumnName", reference.FKColumnName);
                    string strIsNullable = this._dbContext.Database.SqlQuery<string>(query).FirstOrDefault();
                    if (strIsNullable != null && strIsNullable.Equals("YES"))
                    {
                        reference.IsWeakReference = true;
                    }
                }



                //
                // If everything is okay
                // Set result
                if (response != null && response.Count > 0)
                    result = response;

            }
            catch (Exception exc)
            {
                LogService.Log.Error("Can not get reference information of table " + tableName, exc);
            }



            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get list reference by SQL script
        /// </summary>
        private Dictionary<string, List<ReferenceInformation>> GetListReferenceBySQLScript()
        {
            //
            // Initialize
            Dictionary<string, List<ReferenceInformation>> result = new Dictionary<string, List<ReferenceInformation>>();


            //
            // Query about all reference in datatabase
            string sqlQuery = @"SELECT
                                    FKTableName = FK.TABLE_NAME,
                                    FKColumnName = CU.COLUMN_NAME,
                                    PKTableName = PK.TABLE_NAME,
                                    PKColumnName = PT.COLUMN_NAME,
                                    ConstraintName = C.CONSTRAINT_NAME
                                FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
                                    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
                                    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
                                    INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
                                    INNER JOIN (
                                        SELECT i1.TABLE_NAME, i2.COLUMN_NAME
                                        FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                                        INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                                        WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                                    ) PT ON PT.TABLE_NAME = PK.TABLE_NAME";
            try
            {
                LogService.Log.Info("Getting references information.");
                List<ReferenceInformation> listReferences = this._dbContext.Database.SqlQuery<ReferenceInformation>(sqlQuery).ToList();


                //
                // For each reference
                // Try to determinate which reference is weak reference
                // Weak reference is reference allow null value
                string sqlIsWeakReferenceTemplate = @"SELECT IS_NULLABLE
                                              FROM INFORMATION_SCHEMA.COLUMNS 
                                              WHERE TABLE_NAME ='{FKTableName}' and COLUMN_NAME ='{FKColumnName}'";
                foreach (ReferenceInformation reference in listReferences)
                {
                    //
                    // Invoke SQL Script to determinate weak reference or not
                    try
                    {
                        string sqlIsWeakReference = sqlIsWeakReferenceTemplate.Replace("{FKTableName}", reference.FKTableName)
                                                                 .Replace("{FKColumnName}", reference.FKColumnName);
                        string strIsNullable = this._dbContext.Database.SqlQuery<string>(sqlIsWeakReference).FirstOrDefault();
                        if (strIsNullable != null && strIsNullable.Equals("YES"))
                        {
                            reference.IsWeakReference = true;
                        }
                    }
                    catch (Exception exc)
                    {
                        LogService.Log.Error("Can not determinate reference is weak reference or not.", exc);
                        LogService.Log.Error("FK table : " + reference.FKTableName + " ( " + reference.FKColumnName + " ) ");
                        LogService.Log.Error("PK table : " + reference.PKTableName + " ( " + reference.PKColumnName + " ) ");
                        Environment.Exit(0);
                    }


                    //
                    // Add reference information to table
                    if (result.ContainsKey(reference.FKTableName) == false)
                    {
                        result.Add(reference.FKTableName, new List<ReferenceInformation>());
                    }
                    result[reference.FKTableName].Add(reference);
                }
            }
            catch (Exception excExcecQuery)
            {
                LogService.Log.Error("Can not get references information. Terminated.", excExcecQuery);
                Environment.Exit(0);
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get list reference to current table
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<ReferenceInformation> GetListReferenceToCurrentTable(string tableName)
        {
            //
            // Initialize result
            List<ReferenceInformation> result = new List<ReferenceInformation>();


            //
            // Try to invoke db
            try
            {
                //
                // First try to get information about reference
                // (From this table, reference to another table)
                string sqlQuery = @"SELECT
                                    FKTableName = FK.TABLE_NAME,
                                    FKColumnName = CU.COLUMN_NAME,
                                    PKTableName = PK.TABLE_NAME,
                                    PKColumnName = PT.COLUMN_NAME,
                                    ConstraintName = C.CONSTRAINT_NAME
                                FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
                                    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
                                    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
                                    INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
                                    INNER JOIN (
                                        SELECT i1.TABLE_NAME, i2.COLUMN_NAME
                                        FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                                        INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                                        WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                                    ) PT ON PT.TABLE_NAME = PK.TABLE_NAME
                                WHERE PK.TABLE_NAME = '" + tableName + "'";
                List<ReferenceInformation> response = this._dbContext.Database.SqlQuery<ReferenceInformation>(sqlQuery).ToList();



                //
                // Then try to determinate
                // which reference is weak reference
                // Weak reference is reference, which reference table's column allow nulls value
                string queryTemplate = @"SELECT IS_NULLABLE
                                         FROM INFORMATION_SCHEMA.COLUMNS 
                                         WHERE TABLE_NAME ='FKTableName' and COLUMN_NAME ='FKColumnName'";
                foreach (ReferenceInformation reference in response)
                {
                    string query = queryTemplate.Replace("FKTableName", reference.FKTableName)
                                                .Replace("FKColumnName", reference.FKColumnName);
                    string strIsNullable = this._dbContext.Database.SqlQuery<string>(query).FirstOrDefault();
                    if (strIsNullable != null && strIsNullable.Equals("YES"))
                    {
                        reference.IsWeakReference = true;
                    }
                }



                //
                // If everything is okay
                // Set result
                if (response != null && response.Count > 0)
                    result = response;

            }
            catch (Exception)
            {

            }



            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get list primary key of table
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<string> GetPrimaryKeyName(string tableName)
        {
            //
            // Initialize result
            List<string> result = new List<string>();


            //
            // Get
            if (this._listTablePrimaryKeyName.ContainsKey(tableName))
            {
                List<string> value = this._listTablePrimaryKeyName[tableName];
                if (value != null)
                {
                    result = value;
                }
            }

            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get list values of primary keys
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public Dictionary<string, List<object>> GetListPrimaryKeyValue(string tableName)
        {
            //
            // Initialize result
            Dictionary<string, List<object>> result = new Dictionary<string, List<object>>();

            
            //
            // Get list primary key and type accessor
            List<string> listPrimaryKeys = this.GetPrimaryKeyName(tableName);
            TypeAccessor typeAccessor = this.GetTableTypeAccessor(tableName);
            if (listPrimaryKeys.Count == 0 || typeAccessor == null)
            {
                return result;
            }


            //
            // Extract primary value
            foreach (string primaryKey in listPrimaryKeys)
            {
                List<object> listValue = new List<object>();
                foreach (object obj in tableName)
                {
                    try
                    {
                        object value = typeAccessor[obj, primaryKey];
                        listValue.Add(value);
                    }
                    catch (Exception excGetValue)
                    {
                        LogService.Log.Error("Can not get value of column " + primaryKey, excGetValue);
                        continue;
                    }
                }
                result.Add(primaryKey, listValue);
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Check and return result, this table has circle reference or not
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool HasCircleReference(string tableName)
        {
            return HasCircleReference(tableName, null);
        }

        /// <summary>
        /// Tracking circle references
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="tracking"></param>
        /// <returns></returns>
        public bool HasCircleReference(string tableName, List<string> tracking)
        {
            //
            // First, try to get table information
            // and try to get table's reference
            MapTable table = this.GetMapTable(tableName);
            List<ReferenceInformation> listReference = table.GetReference();
            bool result = false;


            //
            // If we can not detect circle reference in this level
            // Try to access deeper level (using recursion algorithm)
            List<string> listTableHasCheck = new List<string>();
            listTableHasCheck.Add(tableName);
            foreach (ReferenceInformation reference in listReference)
            {
                bool response = HasCircleReference(tableName, reference, listTableHasCheck, tracking);
                if (response == true)
                {
                    //
                    // Add tracking if needed
                    if (tracking != null)
                    {
                        tracking.Add(tableName);
                    }
                    result = true;
                    break;
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Has circle reference
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="referenceTable"></param>
        /// <param name="listTableHasCheck"></param>
        /// <returns></returns>
        private bool HasCircleReference(string tableName, ReferenceInformation reference, List<string> listTableHasCheck, List<string> tracking)
        {
            //
            // Initialize result
            bool result = false;

            //
            // Check current reference
            if (reference.PKTableName.Equals(tableName))
            {
                result = true;
            }
            else
            {
                //
                // Try to get referenced table
                // And go deeper (using recursion algorithm)
                MapTable referencedTable = this.GetMapTable(reference.PKTableName);
                List<ReferenceInformation> listReference = referencedTable.GetReference();
                listTableHasCheck.Add(referencedTable.Name);
                foreach (ReferenceInformation childReference in listReference)
                {
                    //
                    // Check
                    if (childReference.PKTableName.Equals(tableName))
                    {
                        // Add to tracking list if needed
                        if (tracking != null)
                        {
                            tracking.Add(referencedTable.Name);
                        }
                        result = true;
                        break;
                    }


                    //
                    // If referenced table is checked
                    // We don't need to go further
                    if (listTableHasCheck.Contains(childReference.PKTableName))
                    {
                        continue;
                    }


                    //
                    // Else try to go deeper
                    bool response = this.HasCircleReference(tableName, childReference, listTableHasCheck, tracking);
                    if (response)
                    {
                        // Add to tracking list if needed
                        if (tracking != null)
                        {
                            tracking.Add(referencedTable.Name);
                        }
                        result = true;
                        break;
                    }
                }
            }



            //
            // Return result
            return result;
        }

        /// <summary>
        /// Remove table from mapping list
        /// </summary>
        /// <param name="tableName"></param>
        public void RemoveTable(string tableName)
        {
            foreach (MapTable table in this._listTable)
                if (table.Name.Equals(tableName))
                {
                    this._listTable.Remove(table);
                    return;
                }
        }

        /// <summary>
        /// Run sql script from file
        /// </summary>
        /// <param name="filePath"></param>
        public void RunSQLScript(string filePath)
        {
            //
            // First, try to open file
            string sqlScript = "";
            try
            {
                StreamReader reader = new StreamReader(filePath);
                sqlScript = reader.ReadToEnd();
            }
            catch (Exception excOpenFile)
            {
                LogService.Log.Error("Can not open file, file path : " + filePath, excOpenFile);
                return;
            }


            //
            // Run sql script
            try
            {
                this._dbContext.Database.ExecuteSqlCommand(sqlScript);
            }
            catch (Exception excRunScript)
            {
                LogService.Log.Error("Can not run sql script.", excRunScript);
            }
        }


        #endregion


        #region PROPERTIES


        /// <summary>
        /// List of database tables
        /// </summary>
        protected List<MapTable> _listTable;
        
        /// <summary>
        /// Store reflection between tableName and DbSet
        /// </summary>
        protected Hashtable _listDbSet;

        /// <summary>
        /// List table type accessor (FastMember library)
        /// </summary>
        protected Hashtable _listTableTypeAccessor;

        /// <summary>
        /// Dictionary to store tempory data
        /// </summary>
        protected Dictionary<string, List<ColumnInformation>> _listTableColumn;

        /// <summary>
        /// Dictionary to store information about unqiue column and group unique column
        /// </summary>
        protected Dictionary<string, List<GroupUniqueColumnInformation>> _listGroupUniqueColumn;

        /// <summary>
        /// Store list table primary key name
        /// </summary>
        protected Dictionary<string, List<string>> _listTablePrimaryKeyName;

        /// <summary>
        /// DbContext
        /// </summary>
        protected DbContext _dbContext;

        /// <summary>
        /// Type of dbContext
        /// </summary>
        protected Type _dbContextType;

        /// <summary>
        /// Get number of table in database
        /// </summary>
        public int NumberOfTable
        {
            get
            {
                return this._listTable.Count;
            }
        }
        

        #endregion
    }
}