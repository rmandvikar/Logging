using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using log4net;
using log4net.Config;

namespace rm.Logging
{
	/// <summary>
	/// Log4Net logger.
	/// </summary>
	internal class Log4NetLogger : ILogger
	{
		#region members
		private ILog log;
		#endregion

		#region ctors
		// static ctor
		static Log4NetLogger()
		{
			var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			// current working dir is project dir instead of {project}/bin/Debug dir
			// see bug: https://github.com/dotnet/project-system/issues/589
			var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), GetConfigFile());
			XmlConfigurator.ConfigureAndWatch(logRepository, new FileInfo(path));
		}
		// ctors
		public Log4NetLogger()
			: this(typeof(Log4NetLogger))
		{ }
		public Log4NetLogger(Type type)
		{
			log = LogManager.GetLogger(type);
		}
		#endregion

		#region configSections methods
		/// <summary>
		/// Returns path of the log4net config file.
		/// </summary>
		private static string GetConfigFile()
		{
			var configSourceValue = GetLog4NetSectionConfigSourceValue();
			var log4netConfigPath = GetLog4NetConfigFilePath(configSourceValue);
			return log4netConfigPath;
		}
		/// <summary>
		/// Returns log4net configSection's configSource value, ex: "AppConfig\log4net.config"
		/// </summary>
		public static string GetLog4NetSectionConfigSourceValue()
		{
			//return @"AppConfig\log4net.config";
			var config = GetConfiguration();
			var log4netSection = GetLog4NetConfigurationSection(config);
			if (log4netSection == null)
			{
				throw new ApplicationException("log4net configSection is not present in web/app config.");
			}
			var configSourceValue = log4netSection.SectionInformation.ConfigSource;
			if (string.IsNullOrWhiteSpace(configSourceValue))
			{
				throw new ApplicationException("log4net configSection's configSource value is not specified in web/app config.");
			}
			return configSourceValue;
		}
		private static Configuration GetConfiguration()
		{
			return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		}
		private static ConfigurationSection GetLog4NetConfigurationSection(
			Configuration config)
		{
			return GetLog4NetConfigurationSection(config.Sections)
				?? GetLog4NetConfigurationSection(config.SectionGroups);
		}
		private static ConfigurationSection GetLog4NetConfigurationSection(
			ConfigurationSectionCollection sections)
		{
			var localSections = sections.Cast<ConfigurationSection>()
				.Where(s => s.SectionInformation.IsDeclared);
			var log4netSection = localSections
				.Where(s => s.SectionInformation.Type.Contains("Log4NetConfigurationSectionHandler"))
				.SingleOrDefault();
			return log4netSection;
		}
		private static ConfigurationSection GetLog4NetConfigurationSection(
			ConfigurationSectionGroupCollection sectionGroups)
		{
			ConfigurationSection log4netSection = null;
			foreach (ConfigurationSectionGroup sectionGroup in sectionGroups)
			{
				log4netSection = GetLog4NetConfigurationSection(sectionGroup.Sections);
				if (log4netSection != null)
				{
					break;
				}
				log4netSection = GetLog4NetConfigurationSection(sectionGroup.SectionGroups);
				if (log4netSection != null)
				{
					break;
				}
			}
			return log4netSection;
		}
		private static string GetLog4NetConfigFilePath(string configSourceValue)
		{
			return configSourceValue;
		}
		#endregion

		#region ILogger methods

		#region Debug
		public void Debug(object message)
		{
			log.Debug(message);
		}
		public void Debug(object message, Exception exception)
		{
			log.Debug(message, exception);
		}
		public void DebugFormat(string format, params object[] args)
		{
			log.DebugFormat(format, args);
		}
		public void DebugFormat(IFormatProvider provider, string format,
			params object[] args)
		{
			log.DebugFormat(provider, format, args);
		}
		#endregion

		#region Info
		public void Info(object message)
		{
			log.Info(message);
		}
		public void Info(object message, Exception exception)
		{
			log.Info(message, exception);
		}
		public void InfoFormat(string format, params object[] args)
		{
			log.InfoFormat(format, args);
		}
		public void InfoFormat(IFormatProvider provider, string format,
			params object[] args)
		{
			log.InfoFormat(provider, format, args);
		}
		#endregion

		#region Warn
		public void Warn(object message)
		{
			log.Warn(message);
		}
		public void Warn(object message, Exception exception)
		{
			log.Warn(message, exception);
		}
		public void WarnFormat(string format, params object[] args)
		{
			log.WarnFormat(format, args);
		}
		public void WarnFormat(IFormatProvider provider, string format,
			params object[] args)
		{
			log.WarnFormat(provider, format, args);
		}
		#endregion

		#region Error
		public void Error(object message)
		{
			log.Error(message);
		}
		public void Error(object message, Exception exception)
		{
			log.Error(message, exception);
		}
		public void ErrorFormat(string format, params object[] args)
		{
			log.ErrorFormat(format, args);
		}
		public void ErrorFormat(IFormatProvider provider, string format,
			params object[] args)
		{
			log.ErrorFormat(provider, format, args);
		}
		#endregion

		#region Fatal
		public void Fatal(object message)
		{
			log.Fatal(message);
		}
		public void Fatal(object message, Exception exception)
		{
			log.Fatal(message, exception);
		}
		public void FatalFormat(string format, params object[] args)
		{
			log.FatalFormat(format, args);
		}
		public void FatalFormat(IFormatProvider provider, string format,
			params object[] args)
		{
			log.FatalFormat(provider, format, args);
		}
		#endregion

		#endregion
	}
}
