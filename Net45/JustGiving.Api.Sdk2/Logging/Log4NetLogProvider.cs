using System;
using log4net;

namespace JustGiving.Api.Sdk2.Logging
{
    public class Log4NetLogProvider : ILogProvider
    {
        private log4net.ILog _log;
        public Log4NetLogProvider()
        {
            log4net.Config.XmlConfigurator.Configure();
            _log = log4net.LogManager.GetLogger(GetType());
        }

        public ILog Log
        {
            get { return _log; }
            set { _log = value; }
        }

        public void Warn(string message)
        {
            _log.Warn(message);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Error(string message, Exception ex = null)
        {
            if (ex == null)
            {
                _log.Error(message);
            }
            else
            {
                _log.Error(message, ex);
            }
        }
    }
}