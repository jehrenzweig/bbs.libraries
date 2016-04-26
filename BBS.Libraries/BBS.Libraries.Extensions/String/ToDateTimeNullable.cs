using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
  public static partial class String
  {
    public static DateTime? ToDateTimeNullable(this string input)
    {
      return (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)
                  ? (DateTime?)null
                  : DateTime.Parse(input));
    }
  }
}
