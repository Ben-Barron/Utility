using log4net;
using log4net.Config;

namespace Utility.Logging.Log4Net
{
    public class Log4NetLogFactory : ILogFactory
    {
        public Log4NetLogFactory(string path, string name)
        {
            GlobalContext.Properties["LogPath"] = path;
            GlobalContext.Properties["LogName"] = name;
            XmlConfigurator.Configure();
        }

        public ILogger GetLogger<T>()
        {
            return new Log4NetLogger(typeof(T));
        }
    }
}
