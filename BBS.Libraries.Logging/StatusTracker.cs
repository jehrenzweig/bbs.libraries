using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Logging
{
    public class StatusTracker
    {
        private readonly StringBuilder _logBuilder;

        private BBS.Libraries.Contracts.ILog ILog;

        public string Log => _logBuilder.ToString();

        public override string ToString()
        {
            return Log;
        }

        public StatusTracker()
        {
            // If bbs.libraries.logging.type == log4net, create new log4net, else add default amiright?  actually, think factory

            ILog = new SystemTraceLogging();

            _logBuilder = new StringBuilder();
        }

        public void AddToLog(string value)
        {
            var logString = $"{DateTime.Now:MM/dd/yyyy hh:mm:ss:fff} - {value} \n";

            ILog.Info(logString);

            _logBuilder.Append(logString);
        }

        public void AddToLog(Exception exception)
        {
            var logString = $"EXCEPTION: {DateTime.Now:MM/dd/yyyy hh:mm:ss:fff} - {exception.Message} \n\t{exception.StackTrace}";

            ILog.Error(logString);

            _logBuilder.Append(logString);
        }
    }
}
