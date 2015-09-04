using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.Common.Exceptions
{
    public static class AppExceptionCodes
    {
        public static readonly string BLOB_STORE_PROVIDER_ERROR_CATEGORY_SYNTAX = GetErrorCode(() => Resource.BlobStoreProvider_ErrorCategorySyntax);
        public static readonly string BLOB_STORE_PROVIDER_ERROR_NAME_SYNTAX = GetErrorCode(() => Resource.BlobStoreProvider_ErrorNameSyntax);
        public static readonly string BLOB_STORE_PROVIDER_ERROR_NOT_FOUND = GetErrorCode(() => Resource.BlobStoreProvider_ErrorNotFound);
        public static readonly string BLOB_STORE_PROVIDER_ERROR_INVALID_KEY = GetErrorCode(() => Resource.BlobStoreProvider_ErrorInvalidKey);
        public static readonly string BLOB_STORE_PROVIDER_ERROR_EXISTS = GetErrorCode(() => Resource.BlobStoreProvider_ErrorBlobExists);

        public static readonly string DATABASE_ERROR_TABLE_NOT_FOUND = GetErrorCode(() => Resource.Database_ErrorTableNotFound);
        public static readonly string DATABASE_ERROR_FIELD_NOT_FOUND = GetErrorCode(() => Resource.Database_ErrorFieldNotFound);
        public static readonly string DATABASE_ERROR_PK_NOT_FOUND = GetErrorCode(() => Resource.Database_ErrorPKNotFound);

        public static readonly string SERVICE_ERROR_APP_SETTING = GetErrorCode(() => Resource.Service_ErrorAppSetting);

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
