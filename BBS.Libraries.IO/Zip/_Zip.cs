using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBS.Libraries.Extensions;
using ICSharpCode.SharpZipLib.Zip;

namespace BBS.Libraries.IO
{
    public partial class Zip
    {
        public static void ZipFile(string zipFile, List<BBS.Libraries.IO.File.FileStream> fileStreams)
        {
            using (var outputStream = new ZipOutputStream(System.IO.File.Create(zipFile)))
            {
                outputStream.SetLevel(9);

                foreach (var item in fileStreams)
                {
                    var zipEntry = new ZipEntry(Path.GetFileName(item.FileName))
                    {
                        DateTime = DateTime.Now
                    };

                    outputStream.PutNextEntry(zipEntry);

                    var bytes = item.Stream.ToByteArray();

                    outputStream.Write(bytes, 0, bytes.Length);
                }

                outputStream.Finish();
            }
        }
    }
}