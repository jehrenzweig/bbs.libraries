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
using System.Net;
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
