using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
  public static partial class String
  {
    public static byte[] ToByteArray(this string helper)
    {
      var output = new List<byte>();
      foreach (var character in helper)
      {
        output.Add(Convert.ToByte(character));
      }
      return output.ToArray();
    }
  }
}
