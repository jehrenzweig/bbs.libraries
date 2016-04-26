using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
  public static partial class String
  {
    public static bool ToBoolean(this string helper)
    {
      if (helper != string.Empty)
      {
        switch (helper.ToLower())
        {
          case "true":
            return true;
            break;
          case "false":
            return false;
            break;
          case "t":
            return true;
            break;
          case "f":
            return false;
            break;
          case "1":
            return true;
            break;
          case "0":
            return false;
            break;
          default:
            return false;
            break;
        }
      }
      else return false;
    }

    public static bool ToBoolean(this string helper, IEnumerable<string> TrueValues = null, IEnumerable<string> FalseValues = null, bool DefaultReturn = false)
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
