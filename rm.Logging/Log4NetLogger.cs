using System;
using log4net;
using log4net.Config;

namespace rm.Logging
{
    /// <summary>
    /// Log4Net logger.
    /// </summary>
    internal class Log4NetLogger : ILogger
    {
        #region members
        private ILog log;
        #endregion

        #region ctors
        // static ctor
        static Log4NetLogger()
        {
            XmlConfigurator.Configure();
        }
        // ctors
        public Log4NetLogger()
            : this(typeof(Log4NetLogger))
        { }
        public Log4NetLogger(Type type)
        {
            log = LogManager.GetLogger(type);
        }
        #endregion

        #region ILogger methods

        #region Debug
        public void Debug(object message)
        {
            log.Debug(message);
        }
        public void Debug(object message, Exception exception)
        {
            log.Debug(message, exception);
        }
        public void DebugFormat(string format, params object[] args)
        {
            log.DebugFormat(format, args);
        }
        public void DebugFormat(IFormatProvider provider, string format,
            params object[] args)
        {
            log.DebugFormat(provider, format, args);
        }
        #endregion

        #region Info
        public void Info(object message)
        {
            log.Info(message);
        }
        public void Info(object message, Exception exception)
        {
            log.Info(message, exception);
        }
        public void InfoFormat(string format, params object[] args)
        {
            log.InfoFormat(format, args);
        }
        public void InfoFormat(IFormatProvider provider, string format,
            params object[] args)
        {
            log.InfoFormat(provider, format, args);
        }
        #endregion

        #region Warn
        public void Warn(object message)
        {
            log.Warn(message);
        }
        public void Warn(object message, Exception exception)
        {
            log.Warn(message, exception);
        }
        public void WarnFormat(string format, params object[] args)
        {
            log.WarnFormat(format, args);
        }
        public void WarnFormat(IFormatProvider provider, string format,
            params object[] args)
        {
            log.WarnFormat(provider, format, args);
        }
        #endregion

        #region Error
        public void Error(object message)
        {
            log.Error(message);
        }
        public void Error(object message, Exception exception)
        {
            log.Error(message, exception);
        }
        public void ErrorFormat(string format, params object[] args)
        {
            log.ErrorFormat(format, args);
        }
        public void ErrorFormat(IFormatProvider provider, string format,
            params object[] args)
        {
            log.ErrorFormat(provider, format, args);
        }
        #endregion

        #region Fatal
        public void Fatal(object message)
        {
            log.Fatal(message);
        }
        public void Fatal(object message, Exception exception)
        {
            log.Fatal(message, exception);
        }
        public void FatalFormat(string format, params object[] args)
        {
            log.FatalFormat(format, args);
        }
        public void FatalFormat(IFormatProvider provider, string format,
            params object[] args)
        {
            log.FatalFormat(provider, format, args);
        }
        #endregion

        #endregion
    }
}
