using Hangfire.Logging;
using NLog;
using System;
using ILog = WebAPI.AppCode.Interfaces.ILog;

namespace WebAPI.AppCode.Reops
{
    public class LogNLog : ILog, IDisposable
    {
        private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        public LogNLog()
        {
        }

        public void Information(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
