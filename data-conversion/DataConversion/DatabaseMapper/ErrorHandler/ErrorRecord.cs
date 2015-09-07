using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataConversion.DatabaseMapper.ErrorHandler
{
    /// <summary>
    /// Provide basic information of error record
    /// </summary>
    public class ErrorRecord
    {
        /// <summary>
        /// Create new error record
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="record"></param>
        public ErrorRecord(string tableName, object record, ErrorType type)
        {
            this._tableName = tableName;
            this._record = record;
            this._type = type;
        }

        /// <summary>
        /// Get table name of record
        /// </summary>
        public string TableName
        {
            get
            {
                return this._tableName;
            }
        }

        /// <summary>
        /// Get error record
        /// </summary>
        public object Record
        {
            get
            {
                return this._record;
            }
        }

        /// <summary>
        /// Get type of error
        /// </summary>
        public ErrorType Type
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// Table name of record
        /// </summary>
        protected string _tableName;

        /// <summary>
        /// Error record handler
        /// </summary>
        protected object _record;

        /// <summary>
        /// Error type
        /// </summary>
        protected ErrorType _type;
    }
}
