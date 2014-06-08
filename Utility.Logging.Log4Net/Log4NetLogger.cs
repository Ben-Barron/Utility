using log4net;
using System;

namespace Utility.Logging.Log4Net
{
    internal class Log4NetLogger : ILogger
    {
        private readonly ILog _logger;

        public Log4NetLogger(Type type)
        {
            _logger = LogManager.GetLogger(type);
        }

        #region "ILogger implementation"

        public void Debug(string message)
        {
            if (!_logger.IsDebugEnabled) return;

            _logger.Debug(message);
        }

        public void Debug(string format, params object[] args)
        {
            if (!_logger.IsDebugEnabled) return;

            _logger.DebugFormat(format, args);
        }

        public void Debug(Exception exception, string message)
        {
            if (!_logger.IsDebugEnabled) return;

            _logger.Debug(message, exception);
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsDebugEnabled) return;

            _logger.Debug(string.Format(format, args), exception);
        }

        public void Info(string message)
        {
            if (!_logger.IsInfoEnabled) return;

            _logger.Info(message);
        }

        public void Info(string format, params object[] args)
        {
            if (!_logger.IsInfoEnabled) return;

            _logger.InfoFormat(format, args);
        }

        public void Info(Exception exception, string message)
        {
            if (!_logger.IsInfoEnabled) return;

            _logger.Info(message, exception);
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsInfoEnabled) return;

            _logger.Info(string.Format(format, args), exception);
        }

        public void Warn(string message)
        {
            if (!_logger.IsWarnEnabled) return;

            _logger.Warn(message);
        }

        public void Warn(string format, params object[] args)
        {
            if (!_logger.IsWarnEnabled) return;

            _logger.WarnFormat(format, args);
        }

        public void Warn(Exception exception, string message)
        {
            if (!_logger.IsWarnEnabled) return;

            _logger.Warn(message, exception);
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsWarnEnabled) return;

            _logger.Warn(string.Format(format, args), exception);
        }

        public void Error(string message)
        {
            if (!_logger.IsErrorEnabled) return;

            _logger.Error(message);
        }

        public void Error(string format, params object[] args)
        {
            if (!_logger.IsErrorEnabled) return;

            _logger.ErrorFormat(format, args);
        }

        public void Error(Exception exception, string message)
        {
            if (!_logger.IsErrorEnabled) return;

            _logger.Error(message, exception);
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsErrorEnabled) return;

            _logger.Error(string.Format(format, args), exception);
        }

        public void Fatal(string message)
        {
            if (!_logger.IsFatalEnabled) return;

            _logger.Fatal(message);
        }

        public void Fatal(string format, params object[] args)
        {
            if (!_logger.IsFatalEnabled) return;

            _logger.FatalFormat(format, args);
        }

        public void Fatal(Exception exception, string message)
        {
            if (!_logger.IsFatalEnabled) return;

            _logger.Fatal(message, exception);
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            if (!_logger.IsFatalEnabled) return;

            _logger.Fatal(string.Format(format, args), exception);
        }

        #endregion
    }
}
