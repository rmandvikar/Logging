using rm.Logging;

namespace rm.LoggingTestWeb
{
    /// <summary>
    /// Uses Log4Net's type Foo logger.
    /// </summary>
    class Foo
    {
        private static readonly ILogger log = Log.OfType<Foo>();
        public void Start()
        {
            new Common(log).Start();
        }
    }
}
