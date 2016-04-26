using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
  public partial class String
  {
    public static Guid? ToGuidNullable(this string value)
    {
      Guid outputGuid;
      if (string.IsNullOrWhiteSpace(value) || ! Guid.TryParse(value, out outputGuid))
      {
        return null;
      }
      else
      {
        return outputGuid;
      }
    }
  }
}
