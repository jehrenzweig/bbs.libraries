using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
  public static partial class Int
  {
    public static Double ToDouble(this int helper)
    {
      return Convert.ToDouble(helper);
    }
  }
}
