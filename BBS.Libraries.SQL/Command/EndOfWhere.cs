﻿//-----------------------------------------------------------------------
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
using System.Text.RegularExpressions;

namespace BBS.Libraries.SQL
{
    public partial class Command
    {
        public bool EndOfWhere()
        {
            return EndOfWhere(string.Empty);
        }

        public bool EndOfWhere(string replaceWith)
        {
            bool flag = false;
            string input = CommandText.ToString();
            Match match = TrailingWhereAndOrRegex.Match(input);
            if (match.Success)
            {
                CommandText.Clear();
                CommandText.Append(input.Remove(input.Length - match.Groups["FullOperator"].Length, match.Groups["FullOperator"].Length));
                if (match.Groups["Operator"].Value.Equals("where", StringComparison.InvariantCultureIgnoreCase))
                {
                    CommandText.Append(match.Groups["LinePrefix"].Value);
                }
                CommandText.Append(replaceWith);
                CommandText.Append(match.Groups["LineSuffix"].Value);
                flag = true;
            }
            return flag;
        }
    }
}
