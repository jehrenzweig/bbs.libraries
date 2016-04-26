using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BBS.Libraries.Emails
{
    public class EmailAddress
    {
        private Regex emailRegex = new Regex(@"^(?<mailbox>[a-zA-Z0-9_\-\.\+]+)@(?<domain>((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3}))(\]?)$");
        public string Domain { get; set; }
        public string MailBox { get; set; }
        public bool IsValid { get; set; }
        public string Value { get; set; }

        public EmailAddress() { }

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
