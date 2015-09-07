using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.Exceptions
{
    public static class ConversionExceptionCodes
    {
        public static readonly string BLOB_STORE_PROVIDER_ERROR_CATEGORY_SYNTAX = GetErrorCode(() => Resources.BlobStoreProvider_ErrorCategorySyntax);
        public static readonly string BLOB_STORE_PROVIDER_ERROR_NAME_SYNTAX = GetErrorCode(() => Resources.BlobStoreProvider_ErrorNameSyntax);
        public static readonly string BLOB_STORE_PROVIDER_ERROR_NOT_FOUND = GetErrorCode(() => Resources.BlobStoreProvider_ErrorNotFound);
        public static readonly string BLOB_STORE_PROVIDER_ERROR_INVALID_KEY = GetErrorCode(() => Resources.BlobStoreProvider_ErrorInvalidKey);
        public static readonly string BLOB_STORE_PROVIDER_ERROR_EXISTS = GetErrorCode(() => Resources.BlobStoreProvider_ErrorBlobExists);

        public static readonly string SERVICE_ERROR_APP_SETTING = GetErrorCode(() => Resources.Service_ErrorAppSetting);

        /// <summary>
        /// Uses lambda expressions to extract the name of the supplied property, which is the same as the error code.
        /// </summary>
        /// <typeparam name="T">Not required</typeparam>
        /// <param name="exp"></param>
        /// <returns></returns>
        private static string GetErrorCode<T>(Expression<Func<T>> exp)
        {
            return (((MemberExpression)(exp.Body)).Member).Name;
        }
    }
}
