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
    public static void MoveFile(string fileArchive, string fileNew)
    {
      var fileInfo = new FileInfo(fileNew);

      if (!System.IO.Directory.Exists(fileInfo.Directory.FullName))
      {
        System.IO.Directory.CreateDirectory(fileInfo.Directory.FullName);
      }
      System.IO.File.Move(fileArchive, FileNameIncrementor(fileNew));
    }

  }
}
