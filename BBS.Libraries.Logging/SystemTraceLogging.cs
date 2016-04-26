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

        public void Error(string value)
        {
            System.Diagnostics.Trace.WriteLine(value);
        }
    }
}
