using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.IO
{
  public partial class File
  {
    public enum FileLocationType
    {
      UNC,
      Local,
      FTP,
      Http,
      Invalid
    }
  }
}
