using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
  public static partial class String
  {
    public static DateTime ToDateTime(this string helper)
    {
      return DateTime.Parse(helper);
    }
  }
}
