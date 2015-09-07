using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion
{
    public class LogService
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static ILog _log = null;

        /// <summary>
        /// Initialize log service
        /// </summary>
        /// <param name="type"></param>
        public static void Initialize(Type type)
        {
            _log = LogManager.GetLogger(type.Name);
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Get log
        /// </summary>
        public static ILog Log
        {
            get
            {
                if (_log == null)
                {
                    _log = LogManager.GetLogger(typeof(LogService).Name);
                    log4net.Config.XmlConfigurator.Configure();
                }
                return _log;
            }
        }
    }
}
