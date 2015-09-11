using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.Common
{
    public class Logger
    {
        private static readonly ILog _logger;
        static Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
            _logger = log4net.LogManager.GetLogger("MyLogger");
        }
        public static void Debug(string message, params object[] args)
        {
            _logger.Debug(string.Format(CultureInfo.InvariantCulture, message, args));
        }

        public static void Debug(string message, Exception exception, params object[] args)
        {
            _logger.Debug(string.Format(CultureInfo.InvariantCulture, message, args), exception);
        }

        public static void Info(string message, params object[] args)
        {
            _logger.Info(string.Format(CultureInfo.InvariantCulture, message, args));
        }

        public static void Warn(string message, params object[] args)
        {
            _logger.Warn(string.Format(CultureInfo.InvariantCulture, message, args));
        }

        public static void Error(string message, params object[] args)
        {
            _logger.Error(string.Format(CultureInfo.InvariantCulture, message, args));
        }

        public static void Error(string message, Exception exception, params object[] args)
        {
            _logger.Error(string.Format(CultureInfo.InvariantCulture, message, args), exception);
        }

        public static void Fatal(string message, params object[] args)
        {
            _logger.Fatal(string.Format(CultureInfo.InvariantCulture, message, args));
        }

        public static void Fatal(string message, Exception exception, params object[] args)
        {
            _logger.Fatal(string.Format(CultureInfo.InvariantCulture, message, args), exception);
        }
    }
}
