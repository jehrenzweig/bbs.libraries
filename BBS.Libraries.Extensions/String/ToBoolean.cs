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

using System.Collections.Generic;
using System.Linq;

namespace BBS.Libraries.Extensions
{
  public static partial class String
  {
    public static bool ToBoolean(this string helper)
    {
      if (helper != string.Empty)
      {
        switch (helper.ToLower())
        {
          case "true":
            return true;
            break;
          case "false":
            return false;
            break;
          case "t":
            return true;
            break;
          case "f":
            return false;
            break;
          case "1":
            return true;
            break;
          case "0":
            return false;
            break;
          default:
            return false;
            break;
        }
      }
      else return false;
    }

    public static bool ToBoolean(this string helper, IEnumerable<string> TrueValues = null, IEnumerable<string> FalseValues = null, bool DefaultReturn = false)
    {
      if (TrueValues != null && TrueValues.Contains(helper))
      {
        return true;
      }
      else if (FalseValues != null && FalseValues.Contains(helper))
      {
        return false;
      }
      else
      {
        return DefaultReturn;
      }
    }
  }
}
