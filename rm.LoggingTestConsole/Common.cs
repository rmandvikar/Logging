using System;
using System.Linq;
using rm.Logging;

namespace rm.LoggingTestConsole
{
	/// <summary>
	/// Helper class.
	/// </summary>
	class Common
	{
		public const int count = 1;
		ILogger log;
		public Common(ILogger log)
		{
			this.log = log;
		}

		public void Start()
		{
			Info("start");
			Debug();
			Error();
			Fatal();
			Info("end");
		}
		private void Debug()
		{
			log.DebugFormat("count: {0}", count);
		}
		private void Info(string message)
		{
			log.Info(message);
			log.InfoFormat("{0} {1}", "static", message);
		}
		private void Error()
		{
			try
			{
				Throw();
			}
			catch (Exception ex)
			{
				log.Error("Error message", ex);
			}
		}
		private void Fatal()
		{
			try
			{
				Throw();
			}
			catch (Exception ex)
			{
				log.Fatal("Fatal message", ex);
			}
		}
		private void Throw()
		{
			foreach (var i in Enumerable.Range(0, count))
			{
				throw new Exception("ex: " + i.ToString(),
					new ApplicationException("inner: " + i.ToString())
					);
			}
		}
	}
}
