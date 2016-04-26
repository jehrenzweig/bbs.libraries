using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBS.Libraries.Contracts;

namespace BBS.Libraries.IO.Manipulators
{
  public class FileManipulatorFactory
  {
    public static IFileManipulator GetManipulator(BBS.Libraries.IO.File.FileLocationType fileLocationType)
    {
      if (fileLocationType == File.FileLocationType.FTP)
      {
        return new BBS.Libraries.IO.Manipulators.Ftp();
      }
      if (fileLocationType == File.FileLocationType.Local || fileLocationType == File.FileLocationType.UNC)
      {
        return new BBS.Libraries.IO.Manipulators.Windows();
      }
      if (fileLocationType == File.FileLocationType.Http)
      {
        return new BBS.Libraries.IO.Manipulators.Http();
      }

      throw new ArgumentException("Incorrect file type.");
    }
  }
}
