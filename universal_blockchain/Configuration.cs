using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;

namespace universal_blockchain
{
	public static class Configuration
    {
		public static ILog GetLogger()
		{
			GlobalContext.Properties["LogFileName"] = "AppName";
			var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

			return LogManager.GetLogger(typeof(Program));
		}
	}
}
