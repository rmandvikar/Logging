using System;
using System.Linq;
using rm.Logging;

namespace rm.LoggingTestConsole
{
    /// <summary>
    /// Uses Log helper class logger.
    /// </summary>
    class Xyzzy
    {
        public const int count = 1;
        public void Start()
        {
            Info("start");
            Debug();
            Error();
            Fatal();
            Info("end");
        }
        private void Debug()
        {
            Log.DebugFormat("count: {0}", count);
        }
        private void Info(string message)
        {
            Log.Info(message);
            Log.InfoFormat("{0} {1}", "static", message);
        }
        private void Error()
        {
            try
            {
                Throw();
            }
            catch (Exception ex)
            {
                Log.Error("Error message", ex);
            }
        }
        private void Fatal()
        {
            try
            {
                Throw();
            }
            catch (Exception ex)
            {
                Log.Fatal("Fatal message", ex);
            }
        }
        private void Throw()
        {
            foreach (var i in Enumerable.Range(0, count))
            {
                throw new Exception("ex: " + i.ToString(),
                    new ApplicationException("inner: " + i.ToString())
                    );
            }
        }
    }
}
