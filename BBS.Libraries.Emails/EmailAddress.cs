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

using System.Text.RegularExpressions;

namespace BBS.Libraries.Emails
{
    public class EmailAddress
    {
        private Regex emailRegex = new Regex(@"^(?<mailbox>[a-zA-Z0-9_\-\.\+]+)@(?<domain>((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3}))(\]?)$");

        public string Domain { get; set; }
        public string MailBox { get; set; }
        public bool IsValid { get; set; }
        public string Value { get; set; }

        public EmailAddress()
        {
        }

        public EmailAddress(string address)
        {
            IsValid = true;

            if (string.IsNullOrWhiteSpace(address) || !emailRegex.IsMatch(address))
            {
                IsValid = false;
            }

            Value = address;
            MailBox = emailRegex.Match(address).Groups["mailbox"].Value;
            Domain = emailRegex.Match(address).Groups["domain"].Value;
        }
    }
}
