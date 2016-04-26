using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.SQL
{
    public partial class Command
    {
        public void Append(string value)
        {
            CommandText.Append(value);
        }
    }
}
