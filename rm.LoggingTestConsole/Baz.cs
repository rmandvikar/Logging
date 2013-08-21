using System.Reflection;
using rm.Logging;

namespace rm.LoggingTestConsole
{
	/// <summary>
	/// Uses Log4Net logger by getting type using reflection.
	/// </summary>
	class Baz
	{
		private static readonly ILogger log =
			Log.OfType(MethodBase.GetCurrentMethod().DeclaringType);
		public void Start()
		{
			new Common(log).Start();
		}
	}
}
