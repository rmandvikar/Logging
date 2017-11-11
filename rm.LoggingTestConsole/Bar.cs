using log4net;
using rm.Logging;

namespace rm.LoggingTestConsole
{
	/// <summary>
	/// Uses type Bar logger.
	/// </summary>
	class Bar
	{
		private static readonly ILog log = Log.OfType<Bar>();
		public void Start()
		{
			new Common(log).Start();
		}
	}
}
