using System;
using log4net;
using log4net.Config;

namespace rm.Logging
{
    /// <summary>
    /// Logger helper class.
    /// </summary>
    public class Log
    {
        #region members
        /// <summary>
        /// Logger for default type.
        /// </summary>
        private static ILog log { get; set; }
        #endregion

        #region ctors
        static Log()
        {
            // configures log4net using config
            XmlConfigurator.Configure();
            log = OfType<Log>();
        }
        #endregion

        #region loggers
        /// <summary>
        /// Default logger type.
        /// </summary>
        public static ILog Default
        {
            get { return log; }
        }
        /// <summary>
        /// Get logger for type <paramref name="T"/>.
        /// </summary>
        public static ILog OfType<T>()
        {
            return LogManager.GetLogger(typeof(T));
        }
        /// <summary>
        /// Get logger for type.
        /// </summary>
        public static ILog OfType(string type)
        {
            return LogManager.GetLogger(type);
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
