using System;
using System.Threading;
using System.Web.UI;

namespace rm.LoggingTestWeb
{
	public partial class Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Log4NetConfigChangeAtRuntimeTest();
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
	}
}