using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BBS.Libraries.Extensions
{
  public static partial class Stream
  {
    public static void Rewind(this System.IO.Stream stream)
    {
      if (stream.Position > 0) stream.Position = 0;
      if (stream.Length > 0) stream.Flush();
      if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
    }
    public static void Rewind(this System.IO.MemoryStream stream)
    {
      if (stream.Position > 0) stream.Position = 0;
      if (stream.Length > 0) stream.Flush();
      if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
    }
  }
}
