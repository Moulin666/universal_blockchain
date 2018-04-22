using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;

namespace universal_blockchain
{
	public static class Configuration
    {
		private static ILog logger { get; set; }

		public static ILog GetLogger()
		{
			if (logger != null)
				return logger;

			GlobalContext.Properties["LogFileName"] = "AppName";
			var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

			logger = LogManager.GetLogger(typeof(Program));
			return logger;
		}
	}
}
