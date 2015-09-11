using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.CleanerTool.Base.DatabaseMapper.Providers.BlobStore
{
    /// <summary>
    /// Singleton provider of Blob Storage functionality
    /// </summary>
    public abstract class BlobStoreProvider
    {
        private static readonly BlobStoreProvider _instance = CreateInstance();

        /// <summary>
        /// 
        /// </summary>
        protected BlobStoreProvider()
        {
        }

        /// <summary>
        /// Returns a singleton instance.
        /// </summary>
        public static BlobStoreProvider Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Returns the singleton instance of the <c>BlobStore</c>
        /// </summary>
        /// <returns>Singleton instance of the <c>BlobStore</c></returns>
        private static BlobStoreProvider CreateInstance()
        {
            return new FileSystemBlobStoreProvider();
        }

        #region Sync

        /// <summary>
        /// Gets the specified blob as a stream
        /// </summary>
        /// <param name="key">Key as returned by <c>PutData</c></param>
        /// <returns>Reader with contents</returns>
        public abstract Stream GetBlob(string key);

        /// <summary>
        /// Gets the specified blob as a byte array - i.e. contents of blob put into memory
        /// </summary>
        /// <param name="key">Key as returned by <c>PutData</c></param>
        /// <returns>Byte array containing the contents of the file</returns>
        public abstract byte[] GetBlobAsByteArray(string key);

        /// <summary>
        /// Deletes the specified blob
        /// </summary>
        /// <param name="key">Key as returned by <c>PutData</c></param>
        public abstract void DeleteBlob(string key);

        /// <summary>
        /// Saves a new blob into the repository
        /// </summary>
        /// <param name="category">Type of data being stored. Only AlphaNumeric characters are supported.</param>
        /// <param name="name">Name or description of the data item. Does not have to be unique. Only valid file name characters are supported.</param>
        /// <param name="contents">Data to store</param>
        /// <returns>Key to uniquely identify the contents. It can be used as input into <c>GetData()</c> to retrieve the contents.</returns>
        public abstract string PutBlob(string category, string name, Stream contents);

        #endregion

        #region Async

        /// <summary>
        /// Gets the specified blob as a stream
        /// </summary>
        /// <param name="key">Key as returned by <c>PutData</c></param>
        /// <returns>Reader with contents</returns>
        public abstract Task<Stream> GetBlobAsync(string key);

        /// <summary>
        /// Gets the specified blob as a byte array - i.e. contents of blob put into memory
        /// </summary>
        /// <param name="key">Key as returned by <c>PutData</c></param>
        /// <returns>Byte array containing the contents of the file</returns>
        public abstract Task<byte[]> GetBlobAsByteArrayAsync(string key);

        /// <summary>
        /// Deletes the specified blob
        /// </summary>
        /// <param name="key">Key as returned by <c>PutData</c></param>
        public abstract Task DeleteBlobAsync(string key);

        /// <summary>
        /// Saves a new blob into the repository
        /// </summary>
        /// <param name="category">Type of data being stored. Only AlphaNumeric characters are supported.</param>
        /// <param name="name">Name or description of the data item. Does not have to be unique. Only valid file name characters are supported.</param>
        /// <param name="contents">Data to store</param>
        /// <returns>Key to uniquely identify the contents. It can be used as input into <c>GetData()</c> to retrieve the contents.</returns>
        public abstract Task<string> PutBlobAsync(string category, string name, Stream contents);

        #endregion
    }
}
