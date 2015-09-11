using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.ErrorHandler;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.Information;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseConversion.CleanerTool.Base.DatabaseMapper.DataValidation.Orphan
{
    public class OrphanRecordValidationThread
    {
        #region CONSTRUCTOR, INITIALIZE


        /// <summary>
        /// Create new orphan record validation thread
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="dbContext"></param>
        public OrphanRecordValidationThread(OrphanRecordValidationThreadManager manager,
                                            DbContext dbContext,
                                            string tableName,
                                            TypeAccessor typeAccessor,
                                            List<ReferenceInformation> listReference)
        {
            this._manager = manager;
            this._dbContext = dbContext;
            this._tableName = tableName;
            this._typeAccessor = typeAccessor;
            this._listReferences = listReference;
            this._isDone = false;
        }


        #endregion


        #region METHODS

        /// <summary>
        /// Start thread
        /// </summary>
        public void Start()
        {
            try
            {
                this._threadHandler = new Thread(Thread);
                this._threadHandler.Start();
            }
            catch (Exception exc)
            {
                LogService.Log.Error("Can not create new thread to validate orphan record.", exc);
                this._isDone = true;
            }
        }

        /// <summary>
        /// Validate thread
        /// </summary>
        protected void Thread()
        {
            //
            // Change status
            this._isDone = false;

            //
            // Get task and validate
            while (this._manager.IsOutOfTask == false)
            {
                //
                // Get task
                object task = this._manager.GetTask();
                if (task == null)
                {
                    continue;
                }


                //
                // Check is orphan record ornot
                // If orphan record
                // Add to error handler manager
                if (this.IsValid(task) == false)
                {
                    ErrorHandlerManager.AddError(this._tableName, task, ErrorType.Orphan);
                }
            }

            //
            // Done
            this._isDone = true;
        }

        /// <summary>
        /// Is done ?
        /// </summary>
        public bool IsDone
        {
            get
            {
                return this._isDone;
            }
        }

        /// <summary>
        /// Check single record is valid or not
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private bool IsValid(object record)
        {
            //
            // Initialize result
            bool result = true;


            //
            // Foreach reference in list reference, try to check
            foreach (ReferenceInformation reference in this._listReferences)
            {
                //
                // Get value
                // If this column does not exist in source database
                // Try to determinate this is weak reference or not
                // If this is weak reference. It's ok
                // But this is not weak reference, this is orphan record
                object value = null;
                try
                {
                    value = this._typeAccessor[record, reference.FKColumnName];
                }
                catch (Exception excGetValue)
                {
                    if (reference.IsWeakReference == false)
                    {
                        LogService.Log.Warn("Can not get column " + reference.FKColumnName + " 's value.", excGetValue);
                        result = false;
                        break;
                    }
                    continue;
                }


                //
                // Check
                if (value == null && reference.IsWeakReference)
                {
                    continue;
                }


                //
                // Get neccessary information for query
                string strValue = "";
                if (value is string)
                {
                    strValue = "'" + value.ToString() + "'";
                }
                else
                {
                    strValue = value.ToString();
                }
                string TABLE_NAME = reference.PKTableName;
                string CONDITION = reference.PKColumnName + " = " + strValue;
                string sqlQuery = TEMPLATE_SELECT_QUERY.Replace(TABLE_NAME_HOLDER, TABLE_NAME)
                                                       .Replace(CONDITION_HOLDER, CONDITION);


                //
                // Check sqlQuery returns data or not
                // If sqlQuery returns data, it means this reference is legal
                // Else, this reference is not
                if (this.HasData(sqlQuery) == false)
                {
                    result = false;
                    break;
                }
            }


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Check SQL query returns data or not
        /// </summary>
        /// <param name="mapDatabase"></param>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        private bool HasData(string sqlQuery)
        {
            //
            // Initialize result
            bool result = false;


            //
            // Try to get new DbContext and check
            try
            {
                //
                // Exec SQL Query
                int count = this._dbContext.Database.SqlQuery<int>(sqlQuery).FirstOrDefault();
                if (count > 0)
                {
                    result = true;
                }
            }
            catch (Exception excExecQuery)
            {
                LogService.Log.Error("Can not excec select query, query = " + sqlQuery, excExecQuery);
            }



            //
            // Return result
            return result;
        }


        #endregion


        #region PROPERTIES


        /// <summary>
        /// Handler to main validation to report task
        /// </summary>
        protected OrphanRecordValidationThreadManager _manager;

        /// <summary>
        /// DbContext handler
        /// </summary>
        protected DbContext _dbContext;

        /// <summary>
        /// Talbe name
        /// </summary>
        protected string _tableName;

        /// <summary>
        /// Type accessor to access record value
        /// </summary>
        protected TypeAccessor _typeAccessor;

        /// <summary>
        /// List references of table
        /// </summary>
        protected List<ReferenceInformation> _listReferences;

        /// <summary>
        /// Thread handler
        /// </summary>
        protected Thread _threadHandler;

        /// <summary>
        /// Is Done
        /// </summary>
        protected bool _isDone;

        /// <summary>
        /// Static temlate to generate SQL Query
        /// This SQL query for checking
        /// </summary>
        protected static string TEMPLATE_SELECT_QUERY = @"SELECT COUNT(*) FROM dbo.{TABLE_NAME} WHERE {CONDITION}";

        /// <summary>
        /// Place holder to insert table name
        /// </summary>
        protected static string TABLE_NAME_HOLDER = "{TABLE_NAME}";

        /// <summary>
        /// Place holder to insert query condition
        /// </summary>
        protected static string CONDITION_HOLDER = "{CONDITION}";


        #endregion
    }
}
