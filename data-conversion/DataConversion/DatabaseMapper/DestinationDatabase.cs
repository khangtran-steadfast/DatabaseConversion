using DataConversion.DatabaseMapper.Information;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper
{
    public delegate void ManualDeleteRecord(DbContext destinationDbContext, object record);

    public abstract class DestinationDatabase : MapDatabase
    {

        #region CONSTRUCTOR, INITIALIZE


        public DestinationDatabase(Type dbContextType)
            : base(dbContextType)
        {
            this._configManualDelete = new Dictionary<string, Delegate>();
            this._configIgnoreReference = new Dictionary<string, List<string>>();
            this._configMapOrder = new Dictionary<string, List<string>>(); 
        }

        
        #endregion


        #region METHODS


        /// <summary>
        /// Add Manual Delete Record
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="manualDelete"></param>
        protected void AddManualDeleteRecord(string table, ManualDeleteRecord manualDelete)
        {
            this._configManualDelete.Add(table, manualDelete);
        }

        /// <summary>
        /// Check we can map this table right now or not
        /// </summary>
        /// <param name="table"></param>
        protected virtual bool CanMap(MapTable table)
        {
            //
            // Initialize result
            bool result = true;


            //
            // Already mapped or not ?
            // If it is already mapped
            // Return false
            if (table.IsMapped)
            {
                result = false;
            }
            else
            {
                //
                // Get config maporder
                // And config ingore reference for this table
                List<string> configMapOrder = null;
                List<string> configIngoreReference = null;
                if (this._configMapOrder.ContainsKey(table.Name))
                {
                    configMapOrder = this._configMapOrder[table.Name];
                }
                if (this._configIgnoreReference.ContainsKey(table.Name))
                {
                    configIngoreReference = this._configIgnoreReference[table.Name];
                }


                //
                // Check map order configuration first
                if (configMapOrder != null)
                {
                    foreach (string prerequisiteTable in configMapOrder)
                    {
                        if (this.GetMapTable(prerequisiteTable).IsMapped == false)
                        {
                            return false;
                        }
                    }
                }


                //
                // Check
                List<ReferenceInformation> listReferences = table.GetReference();
                foreach (ReferenceInformation reference in listReferences)
                {
                    //
                    // Do we ignore this reference ?
                    if (configIngoreReference != null && configIngoreReference.Contains(reference.PKTableName))
                    {
                        continue;
                    }


                    //
                    // If not, try to check
                    // Referenced table is mapped or not
                    // If not, we can not map this table right now
                    MapTable referencedTable = this.GetMapTable(reference.PKTableName);
                    if (referencedTable != null && referencedTable.IsMapped == false)
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
        /// Config list of table to map
        /// We only map table, which is in this list
        /// </summary>
        /// <param name="listTableToMap"></param>
        public void ConfigListTableToMap(List<string> listTableToMap)
        {
            //
            // Set table are not in this list
            // As mapped state
            foreach (MapTable mapTable in this._listTable)
            {
                if (listTableToMap.Contains(mapTable.Name) == false)
                {
                    mapTable.Map();
                }
            }
        }

        /// <summary>
        /// Delete record from table (and all related table)
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="record"></param>
        public void DeleteRecord(string table, object record)
        {
            if (this.IsManualDelete(table))
            {
                Delegate manualDeleteFunction = this.GetManualDeleteFunction(table);
                if (manualDeleteFunction is ManualDeleteRecord)
                {
                    manualDeleteFunction.DynamicInvoke(this._dbContext, record);
                }
            }
            else
            {
                DbSet dbSet = this.GetTable(table);
                dbSet.Remove(record);
            }
        }
        
        /// <summary>
        /// Get next table to map
        /// </summary>
        /// <returns></returns>
        public MapTable NextTable()
        {
            //
            // Initialize result
            MapTable result = null;


            //
            // Check
            foreach (MapTable table in this._listTable)
            {
                if (this.CanMap(table))
                {
                    result = table;
                    break;
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Configure firstTable must be mapped after secondTable
        /// </summary>
        /// <param name="firstTable"></param>
        /// <param name="secondTable"></param>
        public void MapAfter(string firstTable, string secondTable)
        {
            if (this._configMapOrder.ContainsKey(firstTable) == false)
            {
                this._configMapOrder.Add(firstTable, new List<string>());
            }
            if (this._listTable.Any(x => x.Name.Equals(secondTable)))
            {
                this._configMapOrder[firstTable].Add(secondTable);
            }            
        }

        /// <summary>
        /// Configure firstTable must be mapped before secondTable
        /// </summary>
        /// <param name="firstTable"></param>
        /// <param name="secondTable"></param>
        public void MapBefore(string firstTable, string secondTable)
        {
            if (this._configMapOrder.ContainsKey(secondTable) == false)
            {
                this._configMapOrder.Add(secondTable, new List<string>());
            }
            this._configMapOrder[secondTable].Add(firstTable);
        }

        /// <summary>
        /// Is mapping complete ?
        /// </summary>
        /// <returns></returns>
        public bool IsCompleted()
        {
            foreach (MapTable mapTable in this._listTable)
                if (mapTable.IsMapped == false)
                    return false;
            return true;
        }

        /// <summary>
        /// Does this table have manual delete function or not ?
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        protected bool IsManualDelete(string table)
        {
            if (this._configManualDelete.ContainsKey(table))
                return true;
            return false;
        }

        /// <summary>
        /// Tempory ingore this reference when get map order
        /// Because some time, we have circle refrence, so we need to ingore some of them
        /// If not, the algorithm to find map order will be infinite looped
        /// </summary>
        /// <param name="fkTableName"></param>
        /// <param name="pkTableName"></param>
        public void IngoreReferenceWhenGetMapOrder(string fkTableName, string pkTableName)
        {
            if (this._configIgnoreReference.ContainsKey(fkTableName) == false)
            {
                this._configIgnoreReference.Add(fkTableName, new List<string>());
            }
            this._configIgnoreReference[fkTableName].Add(pkTableName);
        }

        /// <summary>
        /// Save changes in destination daa
        /// </summary>
        public void SaveChanges()
        {
            this._dbContext.SaveChanges();
        }

        /// <summary>
        /// Get manual delete delegate
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        protected Delegate GetManualDeleteFunction(string table)
        {
            if (this._configManualDelete.ContainsKey(table))
                return this._configManualDelete[table];
            return null;
        }

        /// <summary>
        /// Get list of table to map
        /// </summary>
        /// <returns></returns>
        public List<MapTable> GetMapOrder()
        {
            //
            // Initialize result
            List<MapTable> result = new List<MapTable>();

            //
            // Loop
            int loopKiller = 0;
            while (this.IsCompleted() == false)
            {
                loopKiller = 1;
                foreach (MapTable table in this._listTable)
                {
                    //
                    // Check which table can be mapped right now
                    if (this.CanMap(table))
                    {
                        loopKiller = 0;
                        table.Map();
                        result.Add(table);
                    }
                }

                if (loopKiller == 1)
                {
                    Console.WriteLine("test");
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Get list of unmap table
        /// </summary>
        /// <returns></returns>
        public List<MapTable> GetUnmapTable()
        {
            List<MapTable> result = new List<MapTable>();
            foreach (MapTable table in this._listTable)
                if (table.IsMapped == false)
                    result.Add(table);
            return result;
        }

        /// <summary>
        /// Remove record
        /// </summary>
        /// <param name="table"></param>
        /// <param name="record"></param>
        public void Remove(string table, object record)
        {
            this.DeleteRecord(table, record);
        }

        /// <summary>
        /// Remove list of item
        /// </summary>
        /// <param name="table"></param>
        /// <param name="list"></param>
        public void RemoveRange(string table, IList list)
        {
            foreach (object child in list)
            {
                this.DeleteRecord(table, child);
            }
        }



        #endregion


        #region PROPERTIES

        /// <summary>
        /// Config manual delete (which table need manual delete)
        /// </summary>
        protected Dictionary<string, Delegate> _configManualDelete;

        /// <summary>
        /// Configure ingore reference
        /// </summary>
        protected Dictionary<string, List<string>> _configIgnoreReference;

        /// <summary>
        /// Config map order
        /// </summary>
        protected Dictionary<string, List<string>> _configMapOrder;

        /// <summary>
        /// Post migration script file path
        /// </summary>
        public string _postMigrationScriptFilePath;

        #endregion
    }
}
