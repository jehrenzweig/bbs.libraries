using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BBS.Libraries.IO
{
  public partial class File
  {
    public static class FileLocationTypeRegexes
    {
      public static Regex Local = new Regex("^[a-z]:\\\\", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
      public static Regex Ftp = new Regex("^(ftp://)", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
      public static Regex Unc = new Regex("^(//[a-z*])", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
      public static Regex Http = new Regex("^(http://)", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
    }
  }
}
