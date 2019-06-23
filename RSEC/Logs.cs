using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net.Config;
using System.IO;

namespace RSEC
{
    public static class Logs
    {
        static log4net.Repository.ILoggerRepository logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
        static ILog logger = LogManager.GetLogger(typeof(Logs));
        static Logs()
        {
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
        public static void sendLog(object message)
        {
            logger.Error(message);
        }
    }
}
