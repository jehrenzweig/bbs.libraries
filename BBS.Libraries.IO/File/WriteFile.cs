using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.IO
{
  public static partial class File
  {
    public static void WriteFile(string fullFileName, MemoryStream bytes, bool createNewFile = true)
    {
      using (var fileStream = new BBS.Libraries.IO.File.FileStream(fullFileName))
      {
        fileStream.FileManipulator.WriteFile(fullFileName, bytes, createNewFile);
      }
    }

    public static void WriteFile(string fullFileName, byte[] bytes, bool createNewFile = true)
    {
      using (var fileStream = new BBS.Libraries.IO.File.FileStream(fullFileName))
      {
        fileStream.FileManipulator.WriteFile(fullFileName, bytes, createNewFile);
      }
    }
  }
}
