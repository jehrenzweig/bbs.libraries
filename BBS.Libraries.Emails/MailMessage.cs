using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Emails
{
    public class MailMessage //: IMailMessage
    {
        public EmailAddress From { get; set; }

        public EmailAddress Sender { get; set; }

        public EmailAddressCollection ReplyToList { get; set; }

        public EmailAddressCollection To { get; set; }

        public EmailAddressCollection CC { get; set; }

        public EmailAddressCollection Bcc { get; set; }

        public MailPriority Priority { get; set; }

        public DeliveryNotificationOptions DeliveryNotificationOptions { get; set; }

        public string Subject { get; set; }

        public int? SubjectEncoding { get; set; }

        public NameValueCollection Headers { get; private set; }

        public int? HeadersEncoding { get; set; }

        public string Body { get; set; }

        public int? BodyEncoding { get; set; }

        public bool IsBodyHtml { get; set; }

        public MailMessageAttachmentCollection Attachments { get; set; }
        
        public MailMessageAlternateViewCollection AlternateViews { get; set; }

        public MailMessage()
        {
            To = new EmailAddressCollection();
            Bcc = new EmailAddressCollection();
            CC = new EmailAddressCollection();
            ReplyToList = new EmailAddressCollection();
            AlternateViews = new MailMessageAlternateViewCollection();
            Attachments = new MailMessageAttachmentCollection();
        }

        public System.Net.Mail.MailMessage Message()
        {
            var result = new System.Net.Mail.MailMessage();
            
            if (this.From != null && result.From == null)
            {
                result.From = new MailAddress(this.From.Value);
            }
            

            foreach (var to in To)
            {
                result.To.Add(new MailAddress(to.Value));
            }

            foreach (var bcc in Bcc)
            {
                result.Bcc.Add(new MailAddress(bcc.Value));
            }

            foreach (var cc in CC)
            {
                result.CC.Add(new MailAddress(cc.Value));
            }

            foreach (var replyTo in ReplyToList)
            {
                result.ReplyToList.Add(new MailAddress(replyTo.Value));
            }

            if (this.Priority != null)
            {
                result.Priority = this.Priority;
            }
            if (this.DeliveryNotificationOptions != null)
            {
                result.DeliveryNotificationOptions = this.DeliveryNotificationOptions;
            }

            result.Subject = this.Subject;
            result.Body = this.Body;
            result.IsBodyHtml = this.IsBodyHtml;

            foreach (var alternateView in AlternateViews)
            {
                result.AlternateViews.Add(alternateView.XAlternateView);
            }

            foreach (var attachment in Attachments)
            {
                result.Attachments.Add(attachment.XAttachment);
            }

            return result;
        }
    }
}
