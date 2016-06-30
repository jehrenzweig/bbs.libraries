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

using System;
using System.IO;
using BBS.Libraries.Contracts;
using BBS.Libraries.Extensions;
using BBS.Libraries.IO.Manipulators;

namespace BBS.Libraries.IO
{
  public static partial class File
  {
    public class FileStream : IDisposable
    {
      public System.IO.Stream Stream { get; set; }
      public long Length { get { return Stream.Length; }}
      public string FileName { get; set; }

      public string FileType { get; set; }

      public FileLocationType LocationType
      {
        get
        {
          if (FileLocationTypeRegexes.Ftp.IsMatch(this.FileName))
          {
            return FileLocationType.FTP;
          }
          if (FileLocationTypeRegexes.Unc.IsMatch(this.FileName))
          {
            return FileLocationType.UNC;
          }
          if (FileLocationTypeRegexes.Local.IsMatch(this.FileName))
          {
            return FileLocationType.Local;
          }
          if (FileLocationTypeRegexes.Http.IsMatch(this.FileName))
          {
            return FileLocationType.Http;
          }

          return FileLocationType.Invalid;
        }
      }

      public IFileManipulator FileManipulator { get; private set; }

      public FileStream(IFileManipulator fileManipulator, string fullFileName) : this(fullFileName)
      {
        this.FileManipulator = fileManipulator;
      }

      public FileStream(string fullFileName, FileMode fileMode, FileAccess fileAccess, FileShare fileShare, bool incrementFileName = true)
      {
        if(incrementFileName)
        {
          FileName = FileNameIncrementor(fullFileName);
        }
        else
        {
          FileName = fullFileName;
        }

        if (this.FileManipulator == null)
        {
          this.FileManipulator = FileManipulatorFactory.GetManipulator(this.LocationType);
        }

        this.Stream = FileManipulator.Open(fullFileName);

        FileType = Path.GetExtension(fullFileName);
      }

      public FileStream(string fullFileName, bool incrementFileName = true)
        : this(fullFileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read, incrementFileName)
      {
      }

      public void Dispose()
      {
        if (this.Stream != null)
        {
          Stream.Rewind();
          Stream.Flush();
          Stream.Close();
        }
      }
    }
  }
}
