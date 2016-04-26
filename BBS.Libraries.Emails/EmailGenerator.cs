using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Emails
{
    public abstract class EmailGenerator
    {
        public static void Send(BBS.Libraries.Emails.MailMessageCollection emailCollection)
        {
            foreach (var email in emailCollection)
            {
                Send(email);
            }
        }

        public static void Send(BBS.Libraries.Emails.MailMessage email)
        {
            using (var smtp = new System.Net.Mail.SmtpClient())
            {
                smtp.Send(email.Message());
            }
        }
    }
}
