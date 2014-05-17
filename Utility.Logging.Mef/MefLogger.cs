using Microsoft.Practices.Prism.Logging;
using System;

namespace Utility.Logging.Mef
{
    public class MefLogger<T> : ILoggerFacade
    {
        private readonly ILogger _logger;

        public MefLogger(ILogFactory logFactory)
        {
            _logger = logFactory.GetLogger<T>();
        }

        public void Log(string message, Category category, Priority priority)
        {
            if (category == Category.Debug)
            {
                _logger.Debug(message);
            }
            else if (category == Category.Exception)
            {
                _logger.Fatal(message);
            }
            else if (category == Category.Info)
            {
                _logger.Info(message);
            }
            else if (category == Category.Warn)
            {
                _logger.Warn(message);
            }
            else
            {
                throw new ArgumentOutOfRangeException(
                    "category",
                    category,
                    "No ILogger support for category.");
            }
        }
    }
}
