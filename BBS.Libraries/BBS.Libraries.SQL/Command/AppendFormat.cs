using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.SQL
{
    public partial class Command
    {
        public void AppendFormat(string value, params object[] args)
        {
            CommandText.AppendFormat(value, args);
        }
    }
}
