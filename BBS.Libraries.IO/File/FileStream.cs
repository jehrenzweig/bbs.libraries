using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
