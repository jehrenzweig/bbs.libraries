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
using System.Reflection;
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
