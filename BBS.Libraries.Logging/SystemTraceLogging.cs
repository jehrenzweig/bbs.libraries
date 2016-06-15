using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Logging
{
    public class SystemTraceLogging : BBS.Libraries.Contracts.ILog
    {
        public void Info(string value)
        {
            System.Diagnostics.Trace.WriteLine(value);
        }

        public void Info(object value)
        {
            Info(value.ToString());
        }

        public void Info(object message, Dictionary<string, string> customProperties)
        {
            Info(message.ToString());
        }

        public void Error(string value)
        {
            System.Diagnostics.Trace.WriteLine(value);
        }

        public void Error(Exception exception)
        {
            Error(exception.Message);
        }

        public void Error(Exception exception, Dictionary<string, string> customProperties)
        {
            Error(exception.Message);
        }
    }
}
