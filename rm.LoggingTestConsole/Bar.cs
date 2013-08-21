using rm.Logging;

namespace rm.LoggingTestConsole
{
	/// <summary>
	/// Uses Log4Net's type Bar logger.
	/// </summary>
	class Bar
	{
		private static readonly ILogger log = Log.OfType<Bar>();
		public void Start()
		{
			new Common(log).Start();
		}
	}
}
