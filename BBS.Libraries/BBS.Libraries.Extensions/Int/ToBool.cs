using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
  public static partial class Int
  {
    public static bool ToBoolean(this int helper)
    {
      switch (helper)
      {
        case 0:
          return false;
          break;
        case 1:
          return true;
          break;
        default:
          return false;
      }
    }

    public static bool ToBoolean(this int helper, IEnumerable<int> TrueValues = null, IEnumerable<int> FalseValues = null, bool DefaultReturn = false)
    {
      if (TrueValues != null && TrueValues.Contains(helper))
      {
        return true;
      }
      else if (FalseValues != null && FalseValues.Contains(helper))
      {
        return false;
      }
      else
      {
        return DefaultReturn;
      }
    }
  }
}
