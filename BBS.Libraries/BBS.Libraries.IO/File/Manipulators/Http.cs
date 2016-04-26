using System;
using System.IO;
using System.Net;
using BBS.Libraries.Contracts;

namespace BBS.Libraries.IO.Manipulators
{
  public class Http : IFileManipulator
  {
    public Stream Open(string fullFileName)
    {
      var stream = new MemoryStream();
      using (var client = new WebClient())
      {
        var clientStream = client.OpenRead(fullFileName);
        clientStream.CopyTo(stream);
      }
      
      return stream;
    }

    public void WriteFile(string fullFileName, MemoryStream bytes, bool createNewFile = true)
    {
      throw new NotImplementedException();
    }

    public void WriteFile(string fullFileName, byte[] bytes, bool createNewFile = true)
    {
      throw new NotImplementedException();
    }
  }
}
