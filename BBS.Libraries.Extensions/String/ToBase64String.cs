using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
  public static partial class String
  {
    public static string ToBase64String(this string helper)
    {
      var byteArray = helper.ToByteArray();
      return Convert.ToBase64String(byteArray);
    }
  }
}
