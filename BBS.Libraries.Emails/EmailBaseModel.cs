using System.Net.Mail;

namespace BBS.Libraries.Emails
{
    public abstract class EmailBaseModel : IEmailBaseModel
    {
        public EmailAddress FromEmailAddress { get; set; }
        public EmailAddressCollection ToEmailAddressCollection { get; set; }
        public EmailAddressCollection CcEmailAddressCollection { get; set; }
        public EmailAddressCollection BccEmailAddressCollection { get; set; }
        public MailMessageAttachmentCollection Attachments { get; set; }
        public MailPriority Priority { get; set; }
    }
}