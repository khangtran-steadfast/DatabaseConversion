using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.ErrorHandler;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.Information;
using FastMember;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.CleanerTool.Base.DatabaseMapper.DataValidation.Orphan
{
    public class OrphanRecordValidation : RecordValidation
    {
        #region CONSTRUCTOR, INITIALIZE


        /// <summary>
        /// Create new validation to detect orphan record
        /// </summary>
        public OrphanRecordValidation()
        {
        }


        #endregion


        #region METHODS


        /// <summary>
        /// Validate database
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="mapDatabase"></param>
        public override void Validate(MappingManager manager, MapDatabase mapDatabase)
        {
        }

        /// <summary>
        /// Validate database
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        public override void Validate(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase)
        {
            //
            // Initialize
            this.MigrationReference(manager, sourceDatabase, destinationDatabase);
            this._threadManager = new OrphanRecordValidationThreadManager(sourceDatabase, destinationDatabase);
            List<string> listTable = sourceDatabase.GetListTable();


            //
            // Start validate
            LogService.Log.Info("Start validate orphan record from database.");
            foreach (string table in listTable)
            {
                LogService.Log.Info("Validate table : " + table);
                this._threadManager.Validate(table);
            }


            //
            // Write SQLScript to Orphans.sql
            LogService.Log.Info("Create Orphans.sql to delete orphan record.");
            ErrorHandlerManager.ExportScriptToDeleteOrphan(sourceDatabase, @"Orphans.sql");
        }

        /// <summary>
        /// Migration reference from destination to source
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        private void MigrationReference(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase)
        {
            List<string> listSourceTableName = sourceDatabase.GetListTable();
            List<string> listDestTableName = destinationDatabase.GetListTable();
            foreach (string sourceTableName in listSourceTableName)
            {
                //
                // Check does it rename or not ?
                string destTableName = manager.GetTableNewName(sourceTableName);
                LogService.Log.Info("Migrate from " + destTableName + " to " + sourceTableName);


                //
                // Then check, it's still exist in destination database or not
                if (listDestTableName.Contains(destTableName) == false)
                {
                    LogService.Log.Info("Table " + sourceTableName + " has been dropped in destination database.");
                    continue;
                }


                //
                // Get MapTable (class contains information about table, includes references)
                MapTable sourceMapTable = sourceDatabase.GetMapTable(sourceTableName);
                MapTable destMapTable = destinationDatabase.GetMapTable(destTableName);


                //
                // Add references
                List<ReferenceInformation> listDestReference = destMapTable.GetReference();
                foreach (ReferenceInformation reference in listDestReference)
                {
                    //
                    // Try to revert from new name of table to old name of table
                    string PKTableOldName = manager.GetTableOldName(reference.PKTableName);
                    string FKTableOldName = manager.GetTableOldName(reference.FKTableName);
                    reference.PKTableName = PKTableOldName;
                    reference.FKTableName = FKTableOldName;


                    //
                    // Add new reference information to sourceMapTable
                    if (sourceMapTable.HasReference(reference) == false)
                    {
                        LogService.Log.Info("Add new reference from " + reference.FKTableName + "(" + reference.FKColumnName + ")" +
                                            "to " + reference.FKTableName + "(" + reference.FKColumnName + ")");
                        sourceMapTable.AddReference(reference);
                    }
                }
            }
        }


        #endregion


        #region PROPERTIES


        /// <summary>
        /// Thread manager
        /// </summary>
        protected OrphanRecordValidationThreadManager _threadManager;


        #endregion
    }
}
