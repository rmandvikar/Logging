using log4net;
using rm.Logging;

namespace rm.LoggingTestConsole
{
    /// <summary>
    /// Uses default type logger.
    /// </summary>
    class Qux
    {
        private static readonly ILog log = Log.Default;
        public void Start()
        {
            new Common(log).Start();
        }
    }
}
