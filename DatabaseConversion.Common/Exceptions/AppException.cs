﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.Common.Exceptions
{
    /// <summary>
    /// Custom Exception class. 
    /// 
    /// This exception implementation attempts to map the provided error to one of the predefined errors
    /// stored in the internal string table. If an entry is found, the internal error message of this exception is set
    /// to the looked up error message, and the original message assumes the role of error code.
    /// </summary>
    public class AppException : ApplicationException
    {
        /// <summary>
        /// Basic implementation.
        /// </summary>
        /// <param name="error"></param>
        public AppException(string errorCode, params object[] placeholders)
            : base(GetMessage(errorCode, placeholders))
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Does the mapping of the provided error code to one of the stored error messages.
        /// </summary>
        /// <param name="error"></param>
        private static string GetMessage(string errorCode, object[] placeholders)
        {
            string errorMessage = Resource.ResourceManager.GetString(errorCode);
            if (errorMessage == null)
            {
                return errorCode;
            }
            else if (placeholders == null || placeholders.Length == 0)
            {
                return errorMessage;
            }
            else
            {
                return string.Format(errorMessage, placeholders);
            }
        }

        /// <summary>
        /// Initialises an exception object with the provided inner exception object.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public AppException(Exception ex, string errorCode, params object[] placeholders)
            : base(GetMessage(errorCode, placeholders), ex)
        {
            this.ErrorCode = errorCode;
        }

        public string ErrorCode { get; private set; }
    }
}
