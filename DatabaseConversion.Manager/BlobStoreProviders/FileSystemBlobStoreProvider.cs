using DatabaseConversion.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatabaseConversion.Manager.BlobStoreProviders
{
    /// <summary>
    /// Implements Blob Storage on the file system
    /// </summary>
    public class FileSystemBlobStoreProvider : BlobStoreProvider
    {
        private const string APP_SETTING_ROOT_DIR = "BlobOutputFolder";

        private string _rootPath = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public FileSystemBlobStoreProvider()
        {
            _rootPath = ConfigurationManager.AppSettings[APP_SETTING_ROOT_DIR];
            if (string.IsNullOrEmpty(_rootPath))
            {
                throw new AppException(AppExceptionCodes.SERVICE_ERROR_APP_SETTING, APP_SETTING_ROOT_DIR, _rootPath);
            }

            if (!_rootPath.EndsWith("\\"))
            {
                _rootPath = _rootPath + "\\";
            }

            return;
        }

        /// <summary>
        /// Creates a file to put data
        /// </summary>
        /// <param name="category">Type of data being stored. Only AlphaNumeric characters are supported.</param>
        /// <param name="name">Name or description of the data item. Does not have to be unique. Only valid file name characters are supported.</param>
        /// <param name="key">Key to identify the blob</param>
        /// <param name="file">FileInfo object</param>
        /// 
        private void CreateFile(string category, string name, out string key, out FileInfo file)
        {
            DateTime ts = DateTime.Now;
            string id = Guid.NewGuid().ToString("N");

            // Check input syntax
            if (!Regex.Match(category, "^[A-Za-z0-9]+$").Success)
            { throw new AppException(AppExceptionCodes.BLOB_STORE_PROVIDER_ERROR_CATEGORY_SYNTAX, "", category); }
            if (!Regex.Match(name, "^[A-Za-z0-9\\._-]+$").Success)
            { throw new AppException(AppExceptionCodes.BLOB_STORE_PROVIDER_ERROR_NAME_SYNTAX, "", name); }

            // Build return key
            key = string.Format("{0}:{1}:{2}:{3}", category, ts.ToString("yyyyMMddHH"), id, name);

            // Make directory where we want to save the data
            string relativePath = string.Format("{0}\\{1}\\{2}\\{3}\\{4}", category, ts.Year,
                ts.Month.ToString("00"), ts.Day.ToString("00"), ts.Hour.ToString("00"));
            DirectoryInfo dir = new DirectoryInfo(_rootPath + relativePath);
            if (!dir.Exists)
            { dir.Create(); }

            // Make the file name - if file exists, rename it
            string fileName = string.Format("{0}_{1}", id, name);
            file = new FileInfo(dir.FullName + "\\" + fileName);

        }

        /// <summary>
        /// Convert a key as returned by <c>PutData()</c> into a file path
        /// </summary>
        /// <param name="Key">Key as returned by <c>PutData()</c></param>
        /// <param name="checkIfFileExists">If true and file does not exist, an error this thrown</param>
        /// <param name="create">Creates the path of path does not exist</param>
        /// <returns>Path to the data file</returns>
        private string UriToPath(string key, bool checkIfFileExists, bool create)
        {
            if (string.IsNullOrEmpty(key))
            { throw new AppException(AppExceptionCodes.BLOB_STORE_PROVIDER_ERROR_INVALID_KEY, "null or empty", key); }

            string[] parts = key.Split(':');
            if (parts.Length != 4)
            { throw new AppException(AppExceptionCodes.BLOB_STORE_PROVIDER_ERROR_INVALID_KEY, "4 parts expected", key); }

            string category = parts[0];
            string ts = parts[1];
            if (ts.Length != 10)
            { throw new AppException(AppExceptionCodes.BLOB_STORE_PROVIDER_ERROR_INVALID_KEY, "timestamp format not 'yyyyMMddHH'", key); }
            string year = ts.Substring(0, 4);
            string month = ts.Substring(4, 2);
            string day = ts.Substring(6, 2);
            string hour = ts.Substring(8, 2);
            string id = parts[2];
            string name = parts[3];

            string relativePath = string.Format("{0}\\{1}\\{2}\\{3}\\{4}", category, year, month, day, hour);
            DirectoryInfo dir = new DirectoryInfo(_rootPath + relativePath);
            if (!dir.Exists)
            {
                if (create)
                {
                    dir.Create();
                }
                else
                {
                    throw new AppException(AppExceptionCodes.BLOB_STORE_PROVIDER_ERROR_NOT_FOUND, key);
                }
            }

            string fileName = string.Format("{0}_{1}", id, name);
            FileInfo file = new FileInfo(dir.FullName + "\\" + fileName);
            if (checkIfFileExists)
            {
                if (!file.Exists)
                {
                    throw new AppException(AppExceptionCodes.BLOB_STORE_PROVIDER_ERROR_NOT_FOUND, key);
                }
            }

            return file.FullName;
        }

        #region Sync

        public override byte[] GetBlobAsByteArray(string key)
        {
            string filePath = UriToPath(key, true, false);
            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            {
                byte[] buff = new byte[file.Length];
                file.Read(buff, 0, (int)file.Length);
                return buff;
            }
        }

        public override Stream GetBlob(string key)
        {
            string filePath = UriToPath(key, true, false);
            return new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }

        public override void DeleteBlob(string key)
        {
            if (string.IsNullOrEmpty(key))
            { return; }

            string filePath = UriToPath(key, false, false);
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            { file.Delete(); }
        }

        public override string PutBlob(string category, string name, Stream contents)
        {
            string key;
            FileInfo file;
            CreateFile(category, name, out key, out file);

            if (file.Exists)
            { throw new AppException(AppExceptionCodes.BLOB_STORE_PROVIDER_ERROR_EXISTS, file.FullName); }

            // Open the file and write it
            byte[] buffer = new byte[4096];
            using (FileStream fs = new FileStream(file.FullName, FileMode.Create, FileAccess.Write))
            {
                int count = contents.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    fs.Write(buffer, 0, count);
                    count = contents.Read(buffer, 0, buffer.Length);
                }
            }

            return key;
        }

        #endregion

        #region Async

        /// <summary>
        /// Gets the specified blob as a byte array - i.e. contents of blob put into memory
        /// </summary>
        /// <param name="key">Key as returned by <c>PutData</c></param>
        /// <returns>Byte array containing the contents of the file</returns>
        public override async Task<byte[]> GetBlobAsByteArrayAsync(string key)
        {
            string filePath = UriToPath(key, true, false);
            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            {
                byte[] buff = new byte[file.Length];
                await file.ReadAsync(buff, 0, (int)file.Length);
                return buff;
            }
        }

#pragma warning disable 1998

        /// <summary>
        /// Gets the specified blob as a stream
        /// </summary>
        /// <param name="key">Key as returned by <c>PutData</c></param>
        /// <returns>Reader with contents</returns>
        public override Task<Stream> GetBlobAsync(string key)
        {
            return Task.Run(() => GetBlob(key));
        }

        /// <summary>
        /// Deletes the specified blob
        /// </summary>
        /// <param name="key">Key as returned by <c>PutData</c></param>
        public override Task DeleteBlobAsync(string key)
        {
            return Task.Run(() => DeleteBlob(key));
        }
#pragma warning restore 1998

        /// <summary>
        /// Saves a new blob into the repository
        /// </summary>
        /// <param name="category">Type of data being stored. Only AlphaNumeric characters are supported.</param>
        /// <param name="name">Name or description of the data item. Does not have to be unique. Only valid file name characters are supported.</param>
        /// <param name="contents">Data to store</param>
        /// <returns>Key to uniquely identify the contents. It can be used as input into <c>GetData()</c> to retrieve the contents.</returns>
        public override async Task<string> PutBlobAsync(string category, string name, Stream contents)
        {
            string key;
            FileInfo file;
            CreateFile(category, name, out key, out file);

            if (file.Exists)
            { throw new AppException(AppExceptionCodes.BLOB_STORE_PROVIDER_ERROR_EXISTS, file.FullName); }

            // Open the file and write it
            byte[] buffer = new byte[4096];
            using (FileStream fs = new FileStream(file.FullName, FileMode.Create, FileAccess.Write))
            {
                int count = contents.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    fs.Write(buffer, 0, count);
                    count = await contents.ReadAsync(buffer, 0, buffer.Length);
                }
                fs.Close();
            }

            return key;
        }

        #endregion
    }
}
