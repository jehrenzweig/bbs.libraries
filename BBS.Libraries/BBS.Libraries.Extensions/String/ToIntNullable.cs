using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
  public static partial class String
  {
    public static int? ToIntNullable(this string input)
    {
      return (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)
                  ? (int?)null
                  : Convert.ToInt32(input));
    }
  }
}
