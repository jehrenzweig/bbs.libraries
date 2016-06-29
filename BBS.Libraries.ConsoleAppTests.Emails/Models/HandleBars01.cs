using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.ConsoleAppTests.Emails.Models
{
    public class HandleBars01 : BBS.Libraries.Emails.EmailBaseModel
    {
        public string FirstName { get; set; }
        public DateTime DateTime => DateTime.UtcNow;
    }
}
