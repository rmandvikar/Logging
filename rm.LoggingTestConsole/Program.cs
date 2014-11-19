using System;
using System.Threading;
using rm.Logging;

namespace rm.LoggingTestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			//LoggingTest();

			Log4NetConfigChangeAtRuntimeTest();
			//GetConfigSectionConfigSourceTest();
		}

		private static void LoggingTest()
		{
			// log with different types
			new Foo().Start();
			new Bar().Start();
			new Baz().Start();
			new Qux().Start();
			new Xyzzy().Start();
		}

		private static void Log4NetConfigChangeAtRuntimeTest()
		{
			var ts = DateTime.UtcNow;
			while (ts.AddMinutes(1) > DateTime.UtcNow)
			{
				new Foo().Start();
				Thread.Sleep(1000);
			}
		}

		private static void GetConfigSectionConfigSourceTest()
		{
			var log4netConfigFilePath = Log.GetLog4NetSectionConfigSourceValue();
		}
	}
}
