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
        void Error(string value);
    }
}
