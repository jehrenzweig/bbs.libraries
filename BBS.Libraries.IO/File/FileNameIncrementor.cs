using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BBS.Libraries.IO
{
  public static partial class File
  {
    private static Regex iterationMatcher = new Regex(@"\.\d$");

    public static string FileNameIncrementor(string fileName)
    {
      while (CurrentFileNameExists(fileName))
      {
        var fileNameOnly = Path.GetFileName(fileName);
        
        var fileInfo = new System.IO.FileInfo(fileName);

        var nameWithIteration = fileNameOnly.Substring(0, fileNameOnly.LastIndexOf("."));
        fileNameOnly = nameWithIteration;

        if (iterationMatcher.IsMatch(nameWithIteration))
        {
          var nameWithoutIteration = nameWithIteration.Substring(0, nameWithIteration.LastIndexOf("."));
          fileNameOnly = nameWithoutIteration;
        }

        var iteration = nameWithIteration.Substring(nameWithIteration.LastIndexOf(".") + 1);

        //Try to convert
        int count;
        var iterationIsNumber = int.TryParse(iteration, out count);
        if (iterationIsNumber)
        {
          count++;
        }
        else
        {
          count = 1;
        }
        
        fileName = fileInfo.Directory + @"\" + fileNameOnly + "." + count + fileInfo.Extension;
      }
      return fileName;
    }
  }
}
