using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
  public static partial class String
  {
    public static string[] ToChunks(this string helper, int chunkSize, bool replaceSpaces = false)
    {
      if (replaceSpaces) helper = helper.Replace(" ", string.Empty);
      var i = 0;
      var chunks = new List<string>();
      while (i < helper.Length)
      {
        if (i + chunkSize < helper.Length)
          chunks.Add(helper.Substring(i, chunkSize));
        else
          chunks.Add(helper.Substring(i, (helper.Length - i)));
        i += chunkSize;
      }
      return chunks.ToArray();
    }
  }
}
