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
using System.Net.Mail;

namespace BBS.Libraries.Emails
{
    public class MailMessageAlternateView
    {

        private AlternateView _alternateView;

        public byte[] Content { get; set; }

        public string ContentType { get; set; }

        public AlternateView XAlternateView
        {
            get
            {
                if (_alternateView == null)
                {
                    return _alternateView = new AlternateView(new MemoryStream(Content), ContentType);
                }
                else
                {
                    return _alternateView;
                }
            }
            set
            {
                if (_alternateView == null)
                {
                    var cs = this.Content;
                    _alternateView = new AlternateView(new MemoryStream(cs), ContentType);
                }
            }
        }

    }
}
