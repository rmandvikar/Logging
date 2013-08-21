using rm.Logging;

namespace rm.LoggingTestConsole
{
    /// <summary>
    /// Uses Log4Net's default type logger.
    /// </summary>
    class Qux
    {
        private static readonly ILogger log = Log.Default;
        public void Start()
        {
            new Common(log).Start();
        }
    }
}
