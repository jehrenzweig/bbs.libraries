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
    public static void CopyFile(string fileArchive, string fileNew, bool deleteOriginal = false)
    {
      if (!System.IO.File.Exists(fileArchive)) throw new FileNotFoundException(string.Format("{0} not found.", fileArchive));
      {
        System.IO.File.Copy(fileArchive, FileNameIncrementor(fileNew));
      }

      if (deleteOriginal)
      {
        System.IO.File.Delete(fileArchive);
      }
    }
  }
}
