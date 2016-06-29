using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

    public abstract class EmailGenerator<T> : EmailGenerator where T : IEmailBaseModel
    {
        protected abstract BBS.Libraries.Emails.MailMessage Generate(IEmailBaseModel emailModel);

        public void GenerateAndSend<T>(T emailModel) where T : IEmailBaseModel
        {
            var email = Generate(emailModel);
            Send(email);
        }
    }
}
