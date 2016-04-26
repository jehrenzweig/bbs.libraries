using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.IO
{
  public static partial class File
  {
    public static string CombinePathAndFileName(string path, string fileName)
    {
      if (path.LastIndexOf("\\") == path.Length - 1)
        path = path.Remove(path.LastIndexOf("\\"), 1);
      return string.Format("{0}\\{1}", path, fileName);
    }
  }
}
