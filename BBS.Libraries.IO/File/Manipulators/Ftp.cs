using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BBS.Libraries.Contracts;

namespace BBS.Libraries.IO.Manipulators
{
  public class Ftp : IFileManipulator
  {
    public Stream Open(string fullFileName)
    {
      var Stream = new MemoryStream();

      var downloadRequest = (FtpWebRequest)WebRequest.Create(string.Format("{0}", fullFileName));
      downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;

      using (var response = (FtpWebResponse)downloadRequest.GetResponse())
      {
        using (var stream = response.GetResponseStream())
        {
          if (stream != null)
          {
            Stream = new MemoryStream();

            stream.CopyTo(Stream);
          }
        }
      }
      downloadRequest.Abort();

      return Stream;
    }

    public void WriteFile(string fullFileName, byte[] bytes, bool createNewFile = true)
    {
      var uploadRequest = (FtpWebRequest)WebRequest.Create(string.Format("{0}", fullFileName));
      uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;

      uploadRequest.ContentLength = bytes.Length;

      using (var requestStream = uploadRequest.GetRequestStream())
      {
        requestStream.Write(bytes, 0, bytes.Length);
      }
    }

    public void WriteFile(string fullFileName, MemoryStream bytes, bool createNewFile = true)
    {
      WriteFile(fullFileName, Extensions.Stream.ToByteArray(bytes), createNewFile);
    }
  }
}
