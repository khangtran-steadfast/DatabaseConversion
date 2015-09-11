using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.Information;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace DatabaseConversion.CleanerTool.Base.DatabaseMapper.Threading
{
    public class SQLThread
    {
        #region CONSTRUCTOR, INITIALIZE


        /// <summary>
        /// Create new SQL Thread
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="isGeneratedScript"></param>
        public SQLThread(SQLMultiThreadingManager manager, bool isGeneratedScript)
        {
            this._sqlMultiThreadManager = manager;
            this._isGeneratedScript = isGeneratedScript;
        }


        #endregion


        #region METHODS


        /// <summary>
        /// Get sql script has been generated
        /// </summary>
        /// <returns></returns>
        public string GetGeneratedScript()
        {
            if (this._isDone)
            {
                return this._sqlGeneratedScript;
            }
            return "";
        }

        /// <summary>
        /// Generate insert script and executive
        /// </summary>
        private void Insert()
        {
            //
            // Initialize script
            string sqlInsert = "";


            //
            // For each record, try to generate sql script
            SQLScriptGenerator scriptGenerator = new SQLScriptGenerator(this._tableName, this._typeAccessor, this._listColumnInformation);
            foreach (object record in this._listTasks)
            {
                try
                {
                    string script = scriptGenerator.GenerateInsertScript(record);
                    sqlInsert = sqlInsert + script + Environment.NewLine;
                }
                catch (Exception exc)
                {
                    LogService.Log.Error("Can not generate insert script for record, table name " + this._tableName, exc);
                }
            }




            //
            // Check we need to excecute this script or generate to file
            if (this._isGeneratedScript)
            {
                this._sqlGeneratedScript = sqlInsert;
            }
            else
            {
                try
                {
                    string sqlTurnOn = "SET IDENTITY_INSERT " + this._tableName + " ON" + Environment.NewLine;
                    string sqlTurnOff = "SET IDENTITY_INSERT " + this._tableName + " OFF" + Environment.NewLine;
                    string sqlTurnOffTrigger = "ALTER TABLE " + this._tableName + " DISABLE TRIGGER ALL" + Environment.NewLine;
                    string sqlTurnOnTrigger = "ALTER TABLE " + this._tableName + " ENABLE TRIGGER ALL" + Environment.NewLine;
                    if (this._sqlMultiThreadManager.HasIdentityColumn(this._tableName))
                    {
                        sqlInsert = sqlTurnOn + sqlInsert + sqlTurnOff;
                    }


                    //
                    // Execute
                    DbContext dbContext = this._sqlMultiThreadManager.GetNewDbContext();
                    dbContext.Database.ExecuteSqlCommand(sqlInsert);
                }
                catch (Exception excExecSQL)
                {
                    LogService.Log.Error("Can not execute SQL script.", excExecSQL);
                }
            }
        }

        /// <summary>
        /// Start insert thread
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="entityType"></param>
        public void Insert(string tableName, List<ColumnInformation> listColumnInformation, TypeAccessor typeAccessor)
        {
            this._isDone = false;
            this._listTasks = new List<object>();
            this._tableName = tableName;
            this._listColumnInformation = listColumnInformation;
            this._typeAccessor = typeAccessor;

            //
            // Try to start SQL thread
            try
            {
                this._thread = new Thread(ThreadInsert);
                this._thread.Start();
            }
            catch (Exception excStartSQLThread)
            {
                LogService.Log.Error("Can not create new SQL Thread.", excStartSQLThread);
                this._isDone = true;
            }
        }

        /// <summary>
        /// Thread insert
        /// </summary>
        protected void ThreadInsert()
        {
            //
            // Set flag as busy
            this._isDone = false;


            //
            // First, try to get task from manager
            // As much as you want (LOL)
            while (this._sqlMultiThreadManager.OutOfTask == false)
            {
                object task = this._sqlMultiThreadManager.GetTask();
                if (task != null)
                {
                    this._listTasks.Add(task);
                }
            }


            //
            // Make sure that we have something to insert
            if (this._listTasks.Count > 0)
            {
                this.Insert();
            }


            //
            // Set flag as done
            this._isDone = true;
        }


        #endregion


        #region PROPERTIES


        /// <summary>
        /// Is Done ?
        /// </summary>
        public bool IsDone
        {
            get
            {
                return this._isDone;
            }
        }

        /// <summary>
        /// Is Done ?
        /// </summary>
        private bool _isDone;

        /// <summary>
        /// List tasks
        /// </summary>
        private List<object> _listTasks;

        /// <summary>
        /// Table name
        /// </summary>
        private string _tableName;

        /// <summary>
        /// List column information
        /// </summary>
        private List<ColumnInformation> _listColumnInformation;

        /// <summary>
        /// TypeAccessor to access record value
        /// </summary>
        private TypeAccessor _typeAccessor;
        
        /// <summary>
        /// SQLMultiThreadManager handler
        /// </summary>
        private SQLMultiThreadingManager _sqlMultiThreadManager;

        /// <summary>
        /// Thread handler
        /// </summary>
        private Thread _thread;

        /// <summary>
        /// Handler to generated sql script
        /// </summary>
        private string _sqlGeneratedScript;

        /// <summary>
        /// Bool flag to determinate we generate SQL script to file
        /// Or execute it
        /// </summary>
        private bool _isGeneratedScript;


        #endregion
    }
}
