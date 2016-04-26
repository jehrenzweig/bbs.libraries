using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using BBS.Libraries.Extensions;

namespace BBS.Libraries.IO.Virtual
{
    public class LocalVirtualFile : VirtualFile
    {
        public string virtualFileName;
        public string virtualNamespace;

        public LocalVirtualFile(string @namespace, string VirtualPath)
            : base(VirtualPath)
        {
            virtualNamespace = @namespace;
            virtualFileName = VirtualPath; //VirtualPath.Replace(@namespace, string.Empty);
        }

        public override string ToString()
        {
            var result = string.Empty;
            using (var sr = new StreamReader(this.Open()))
            {
                sr.BaseStream.Rewind();
                result = sr.ReadToEnd();
            }
            return result;
        }

        public override System.IO.Stream Open()
        {
            if (virtualFileName != null || virtualFileName.Equals(string.Empty))
            {
                System.IO.Stream result = new MemoryStream();

                var assembly = Assembly.ReflectionOnlyLoad(this.virtualNamespace);


                string resourceName = string.Empty;
                if (HttpContext.Current == null)
                {
                    resourceName = string.Format("{0}", this.virtualFileName.Replace("~", string.Empty).Replace('/', '.'));
                }
                else
                {
                    resourceName = VirtualPathUtility.ToAbsolute(this.virtualFileName).Replace('/', '.');
                }
                resourceName = resourceName.Substring(1);
                using (System.IO.Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    stream.CopyTo(result);
                }

                return result;
            }
            return null;
        }
    }
}
