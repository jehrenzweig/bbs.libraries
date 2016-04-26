using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace BBS.Libraries.IO.Virtual
{
  public class VirtualFileProvider : System.Web.Hosting.VirtualPathProvider
  {
    public bool IsPahtVirtual(string virtualPath)
    {
      var checkPath = VirtualPathUtility.ToAppRelative(virtualPath);
      return checkPath.StartsWith("~/virtual".ToLower().ToString(), StringComparison.InvariantCultureIgnoreCase);
    }

    public override bool FileExists(string virtualPath)
    {
      return true;
    }

    public override VirtualFile GetFile(string virtualPath)
    {
      var file = new LocalVirtualFile(string.Empty, virtualPath);
      if (file.virtualFileName == null)
      {
        return Previous.GetFile(virtualPath);
      }
      return file;
    }

    public VirtualFileProvider()
      : base()
    {

    }
  }
}
