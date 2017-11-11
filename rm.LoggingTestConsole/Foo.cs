using log4net;
using rm.Logging;

namespace rm.LoggingTestConsole
{
	/// <summary>
	/// Uses type Foo logger.
	/// </summary>
	class Foo
	{
		private static readonly ILog log = Log.OfType<Foo>();
		public void Start()
		{
			new Common(log).Start();
		}
	}
}
