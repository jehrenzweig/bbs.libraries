using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBS.Libraries.Extensions;

namespace BBS.Libraries.IO
{
  public static partial class File
  {
    public static void Rewind(this FileStream fileStream)
    {
      if (fileStream.Stream.Position > 0)
      {
        fileStream.Stream.Position = 0;
      }

      if (fileStream.Stream.Length > 0)
      {
        fileStream.Stream.Flush();
      }

      if (fileStream.Stream.CanSeek)
      {
        fileStream.Stream.Seek(0, SeekOrigin.Begin);
      }
    }
  }
}
