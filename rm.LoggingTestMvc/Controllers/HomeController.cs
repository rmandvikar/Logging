using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace rm.LoggingTestMvc.Controllers
{
	public class HomeController : Controller
	{
		//
		// GET: /Home/
		public ActionResult Index()
		{
			Log4NetConfigChangeAtRuntimeTest();
			return View();
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
