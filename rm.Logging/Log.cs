using System;
using System.Collections.Specialized;
using System.Configuration;

namespace rm.Logging
{
    /// <summary>
    /// Logger helper class.
    /// </summary>
    public static class Log
    {
        #region members
        /// <summary>
        /// Separator string.
        /// </summary>
        private static readonly string separator = ": ";
        private static ILogger log = GetLoggerFromConfig();
        private static ILogger GetLoggerFromConfig()
        {
            ILogger logger;
            try
            {
                var loggingSection = (NameValueCollection)ConfigurationManager.GetSection("Logging");
                var typeName = loggingSection["logger"];
                var type = Type.GetType(typeName);
                logger = (ILogger)Activator.CreateInstance(type);
                return logger;
            }
            catch
            {
                logger = OfType<Log4NetLogger>();
            }
            return logger;
        }
        #endregion

        #region loggers
        /// <summary>
        /// Default logger type.
        /// </summary>
        public static ILogger Default
        {
            get { return log; }
        }
        /// <summary>
        /// Get logger for type <paramref name="T"/>.
        /// </summary>
        public static ILogger OfType<T>()
        {
            return OfType(typeof(T));
        }
        /// <summary>
        /// Get logger for type.
        /// </summary>
        public static ILogger OfType(Type type)
        {
            return new Log4NetLogger(type);
        }
        #endregion

        #region test methods
        public static string GetLog4NetSectionConfigSourceValue()
        {
            return Log4NetLogger.GetLog4NetSectionConfigSourceValue();
        }
        #endregion

        #region wrapper methods

        #region Debug
        public static void Debug(object message)
        {
            log.Debug(message);
        }
        public static void Debug(object message, Exception exception)
        {
            log.Debug(message, exception);
        }
        public static void Debug(object message1, object message2)
        {
            log.DebugFormat("{0}{1}{2}", message1, separator, message2);
        }
        public static void DebugFormat(string format, params object[] args)
        {
            log.DebugFormat(format, args);
        }
        public static void DebugFormat(IFormatProvider provider, string format,
            params object[] args)
        {
            log.DebugFormat(provider, format, args);
        }
        #endregion

        #region Info
        public static void Info(object message)
        {
            log.Info(message);
        }
        public static void Info(object message, Exception exception)
        {
            log.Info(message, exception);
        }
        public static void Info(object message1, object message2)
        {
            log.InfoFormat("{0}{1}{2}", message1, separator, message2);
        }
        public static void InfoFormat(string format, params object[] args)
        {
            log.InfoFormat(format, args);
        }
        public static void InfoFormat(IFormatProvider provider, string format,
            params object[] args)
        {
            log.InfoFormat(provider, format, args);
        }
        #endregion

        #region Warn
        public static void Warn(object message)
        {
            log.Warn(message);
        }
        public static void Warn(object message, Exception exception)
        {
            log.Warn(message, exception);
        }
        public static void Warn(object message1, object message2)
        {
            log.WarnFormat("{0}{1}{2}", message1, separator, message2);
        }
        public static void WarnFormat(string format, params object[] args)
        {
            log.WarnFormat(format, args);
        }
        public static void WarnFormat(IFormatProvider provider, string format,
            params object[] args)
        {
            log.WarnFormat(provider, format, args);
        }
        #endregion

        #region Error
        public static void Error(object message)
        {
            log.Error(message);
        }
        public static void Error(object message, Exception exception)
        {
            log.Error(message, exception);
        }
        public static void Error(object message1, object message2)
        {
            log.ErrorFormat("{0}{1}{2}", message1, separator, message2);
        }
        public static void ErrorFormat(string format, params object[] args)
        {
            log.ErrorFormat(format, args);
        }
        public static void ErrorFormat(IFormatProvider provider, string format,
            params object[] args)
        {
            log.ErrorFormat(provider, format, args);
        }
        #endregion

        #region Fatal
        public static void Fatal(object message)
        {
            log.Fatal(message);
        }
        public static void Fatal(object message, Exception exception)
        {
            log.Fatal(message, exception);
        }
        public static void Fatal(object message1, object message2)
        {
            log.FatalFormat("{0}{1}{2}", message1, separator, message2);
        }
        public static void FatalFormat(string format, params object[] args)
        {
            log.FatalFormat(format, args);
        }
        public static void FatalFormat(IFormatProvider provider, string format,
            params object[] args)
        {
            log.FatalFormat(provider, format, args);
        }
        #endregion

        #endregion
    }
}
