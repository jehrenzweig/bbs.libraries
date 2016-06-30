//-----------------------------------------------------------------------
//    MIT License
//
//    Copyright (c) Wednesday, June 29, 2016 1:15:39 PM Betabyte Software
//
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the "Software"), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:
//
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.

//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//    SOFTWARE.
//-----------------------------------------------------------------------

using System.IO;
using System.Text.RegularExpressions;

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
