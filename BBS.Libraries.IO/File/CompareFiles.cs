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
    public static bool CompareFiles(string fileNameOriginal, string fileNameCompareTo)
    {
      if (!System.IO.File.Exists(fileNameOriginal) || !System.IO.File.Exists(fileNameCompareTo)) throw new FileNotFoundException("File not found");

      var file = System.IO.File.ReadAllBytes(fileNameOriginal);
      var fileCompare = System.IO.File.ReadAllBytes(fileNameCompareTo);

      if (file == null || fileCompare == null) throw new ArgumentNullException("One or more of the files to be compared are null.");

      return file.SequenceEqual(fileCompare);
    }
  }
}
