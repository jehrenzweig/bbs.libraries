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

using System;

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
