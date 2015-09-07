using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversionTool.ManualMappingTable
{
    /// <summary>
    /// This class allow us to share data across manual mapping function
    /// </summary>
    public class ManualMappingDropBox
    {
        /// <summary>
        /// Static constructor, initialize for drop box
        /// </summary>
        static ManualMappingDropBox()
        {
            _storage = new Dictionary<string, object>();
        }

        /// <summary>
        /// Share data with string key to access
        /// </summary>
        /// <param name="key">String key to access data</param>
        /// <param name="data">Share data</param>
        public static void ShareData(string key, object data)
        {
            _storage.Add(key, data);
        }

        /// <summary>
        /// Get share data by key
        /// </summary>
        /// <param name="key">String key to access data</param>
        /// <returns></returns>
        public static object GetData(string key)
        {
            if (_storage.ContainsKey(key))
            {
                return _storage[key];
            }
            return null;
        }

        /// <summary>
        /// Release data
        /// </summary>
        /// <param name="key">String key to access data</param>
        public static void ReleaseData(string key)
        {
            _storage.Remove(key);
        }

        /// <summary>
        /// Temp storage
        /// </summary>
        private static Dictionary<string, object> _storage;
    }
}
