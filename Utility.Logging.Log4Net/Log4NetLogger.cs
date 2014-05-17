﻿using log4net;
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
#if DEBUG
            _logger.Debug(message);
#endif
        }

        public void Debug(string format, params object[] args)
        {
#if DEBUG
            _logger.DebugFormat(format, args);
#endif
        }

        public void Debug(Exception exception, string message)
        {
#if DEBUG
            _logger.Debug(message, exception);
#endif
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
#if DEBUG
            _logger.Debug(String.Format(format, args), exception);
#endif
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Info(string format, params object[] args)
        {
            _logger.InfoFormat(format, args);
        }

        public void Info(Exception exception, string message)
        {
            _logger.Info(message, exception);
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            _logger.Info(String.Format(format, args), exception);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Warn(string format, params object[] args)
        {
            _logger.WarnFormat(format, args);
        }

        public void Warn(Exception exception, string message)
        {
            _logger.Warn(message, exception);
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            _logger.Warn(String.Format(format, args), exception);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(string format, params object[] args)
        {
            _logger.ErrorFormat(format, args);
        }

        public void Error(Exception exception, string message)
        {
            _logger.Error(message, exception);
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            _logger.Error(String.Format(format, args), exception);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(string format, params object[] args)
        {
            _logger.FatalFormat(format, args);
        }

        public void Fatal(Exception exception, string message)
        {
            _logger.Fatal(message, exception);
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            _logger.Fatal(String.Format(format, args), exception);
        }

        #endregion
    }
}