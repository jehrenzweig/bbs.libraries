using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.IO
{
  public static partial class File
  {
    private static bool CurrentFileNameExists(string fileName)
    {
      return System.IO.File.Exists(fileName);
    }
  }
}
