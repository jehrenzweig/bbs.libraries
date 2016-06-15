using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBS.Libraries.Contracts;

namespace BBS.Libraries.Logging
{
    public class StatusTracker
    {
        private readonly StringBuilder _logBuilder;

        private BBS.Libraries.Contracts.ILog Logger;

        public string Log => _logBuilder.ToString();

        public override string ToString()
        {
            return Log;
        }

        public StatusTracker(ILog logger) : this()
        {
            Logger = logger;
        }

        public StatusTracker()
        {
            _logBuilder = new StringBuilder();

            if (Logger == null)
            {
                Logger = new SystemTraceLogging();
            }
        }

        public void AddToLog(string value)
        {
            var logString = $"{DateTime.Now:MM/dd/yyyy hh:mm:ss:fff} - {value} \n";

            Logger.Info(logString);

            _logBuilder.Append(logString);
        }

        public void AddToLog(Exception exception)
        {
            var logString = $"EXCEPTION: {DateTime.Now:MM/dd/yyyy hh:mm:ss:fff} - {exception.Message} \n\t{exception.StackTrace}";

            Logger.Error(logString);

            _logBuilder.Append(logString);
        }
    }
}
