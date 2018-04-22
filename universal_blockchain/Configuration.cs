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
<<<<<<< HEAD
			if (logger != null)
				return logger;

			GlobalContext.Properties["LogFileName"] = "AppName";
=======
			GlobalContext.Properties["LogFileName"] = "Universal_Blockchain";
>>>>>>> 0b154ae21a4607539b560950a39fb8f98fa58ddd
			var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

			logger = LogManager.GetLogger(typeof(Program));
			return logger;
		}
	}
}
