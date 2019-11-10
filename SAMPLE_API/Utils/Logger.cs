using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMPLE_API.Utils
{
    public class Logger
    {
        private static readonly Logger _instance = new Logger();
        protected ILog monitoringLogger;
        protected static ILog debugLogger;

        private const string LINE_SEPARATOR       = "**************************************************************************************************";
        private static string LINE_DATE_SEPARATOR = "***************************************" + DateTime.Now.ToString() + "***************************************";

        internal static void Info(string v1, string v2, object p, object iNFO)
        {
            throw new NotImplementedException();
        }

        private const string TAB_SEPARATOR = "|";

        private Logger()
        {
            monitoringLogger = LogManager.GetLogger("MonitoringLogger");
            debugLogger = LogManager.GetLogger("DebugLogger");
        }

        public class Level
        {
            public const string OFF = "OFF";
            public const string ALL = "ALL";
            public const string ERROR = "ERROR";
            public const string INFO = "INFORMATION";
            public const string DEBUG = "DEBUG";
        }

        /// <summary>  
        /// Used to log Debug messages in an explicit Debug Logger  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Debug(string message)
        {
            debugLogger.Debug(message);
        }


        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Debug(string message, System.Exception exception)
        {
            debugLogger.Debug(message, exception);
        }


        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Info(string message, string hearder, string data, string level)
        {
            _instance.monitoringLogger.Info(LINE_SEPARATOR);
            _instance.monitoringLogger.Info(LINE_DATE_SEPARATOR);
            _instance.monitoringLogger.Info(level);
            _instance.monitoringLogger.Info(message);
            _instance.monitoringLogger.Info(hearder);
            _instance.monitoringLogger.Info(data);

        }

        public static void Info(string message, string level)
        {
            Info(message, null, null, level);
        }

        public static void Error(string message, string hearder, string data, string level)
        {
            _instance.monitoringLogger.Info(LINE_SEPARATOR);
            _instance.monitoringLogger.Info(LINE_DATE_SEPARATOR);
            _instance.monitoringLogger.Info(level);
            _instance.monitoringLogger.Info(message);
            _instance.monitoringLogger.Info(hearder);
            _instance.monitoringLogger.Info(data);

        }

        internal static void Error(string v, Exception ex, object eRROR)
        {
            throw new NotImplementedException();
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Info(string message, System.Exception exception, string level)
        {
            _instance.monitoringLogger.Info(message, exception);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Warn(string message)
        {
            _instance.monitoringLogger.Warn(message);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Warn(string message, System.Exception exception)
        {
            _instance.monitoringLogger.Warn(message, exception);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Error(string message, string level)
        {
            _instance.monitoringLogger.Error(message);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Error(string message, System.Exception exception, string level)
        {
            _instance.monitoringLogger.Error(message, exception);
        }


        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        public static void Fatal(string message)
        {
            _instance.monitoringLogger.Fatal(message);
        }

        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="message">The object message to log</param>  
        /// <param name="exception">The exception to log, including its stack trace </param>  
        public static void Fatal(string message, System.Exception exception)
        {
            _instance.monitoringLogger.Fatal(message, exception);
        }
    }
}