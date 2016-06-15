using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Contracts
{
    public interface ILog
    {
        void Info(string value);
        void Info(object value);
        void Info(object message, Dictionary<string, string> customProperties);
        void Error(string value);
        void Error(Exception exception);
        void Error(Exception exception, Dictionary<string, string> customProperties);
    }
}
