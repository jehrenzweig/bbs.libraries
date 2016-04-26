using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using BBS.Libraries.Contracts;

namespace BBS.Libraries.IO.Manipulators
{
  public class Windows : IFileManipulator
  {
    public Stream Open(string fullFileName)
    {
      if(System.IO.File.Exists(fullFileName))
      {
        return new System.IO.FileStream(fullFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
      }
      
      return null;
    }

    public void WriteFile(string fullFileName, MemoryStream bytes, bool createNewFile = true)
    {
      WriteFile(fullFileName, bytes.ToArray(), createNewFile);
    }

    public void WriteFile(string fullFileName, byte[] bytes, bool createNewFile = true)
    {
      if (createNewFile)
      {
        fullFileName = BBS.Libraries.IO.File.FileNameIncrementor(fullFileName);
      }

      var fileInfo = new System.IO.FileInfo(fullFileName);

      fileInfo.Directory?.Create();

      System.IO.File.WriteAllBytes(fullFileName, bytes);
    }
  }
}
