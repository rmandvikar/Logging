using System.Reflection;
using log4net;
using rm.Logging;

namespace rm.LoggingTestConsole
{
	/// <summary>
	/// Uses logger by getting type using reflection.
	/// </summary>
	class Baz
	{
		private static readonly ILog log =
			Log.OfType(MethodBase.GetCurrentMethod().DeclaringType.Name);
		public void Start()
		{
			new Common(log).Start();
		}
	}
}
