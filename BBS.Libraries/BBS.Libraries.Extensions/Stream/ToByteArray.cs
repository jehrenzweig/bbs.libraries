using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
  public static partial class Stream
  {
    public static byte[] ToByteArray(this System.IO.Stream helper)
    {
      var output = new byte[helper.Length];

      helper.Rewind();

      byte[] buffer = new byte[helper.Length];
      int totalBytesRead = 0;
      int bytesRead;

      while ((bytesRead = helper.Read(buffer, totalBytesRead, buffer.Length - totalBytesRead)) > 0)
      {
        totalBytesRead += bytesRead;

        if (totalBytesRead == buffer.Length)
        {
          int nextByte = helper.ReadByte();
          if (nextByte != -1)
          {
            byte[] temp = new byte[buffer.Length*2];
            Buffer.BlockCopy(buffer, 0, temp, 0, buffer.Length);
            Buffer.SetByte(temp, totalBytesRead, (byte) nextByte);
            buffer = temp;
            totalBytesRead++;
          }
        }
      }

      output = buffer;

      return output;
    }
  }
}
