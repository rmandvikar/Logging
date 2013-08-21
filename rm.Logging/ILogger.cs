using System;

namespace rm.Logging
{
    /// <summary>
    /// Defines methods for logging.
    /// </summary>
    public interface ILogger
    {
        #region Debug
        void Debug(object message);
        void Debug(object message, Exception exception);
        void DebugFormat(string format, params object[] args);
        void DebugFormat(IFormatProvider provider, string format,
            params object[] args);
        #endregion

        #region Info
        void Info(object message);
        void Info(object message, Exception exception);
        void InfoFormat(string format, params object[] args);
        void InfoFormat(IFormatProvider provider, string format,
            params object[] args);
        #endregion

        #region Warn
        void Warn(object message);
        void Warn(object message, Exception exception);
        void WarnFormat(string format, params object[] args);
        void WarnFormat(IFormatProvider provider, string format,
            params object[] args);
        #endregion

        #region Error
        void Error(object message);
        void Error(object message, Exception exception);
        void ErrorFormat(string format, params object[] args);
        void ErrorFormat(IFormatProvider provider, string format,
            params object[] args);
        #endregion

        #region Fatal
        void Fatal(object message);
        void Fatal(object message, Exception exception);
        void FatalFormat(string format, params object[] args);
        void FatalFormat(IFormatProvider provider, string format,
            params object[] args);
        #endregion
    }
}
