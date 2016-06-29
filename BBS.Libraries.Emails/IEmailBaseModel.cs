using System.Net.Mail;
using BBS.Libraries.Contracts;

namespace BBS.Libraries.Emails
{
    public interface IEmailBaseModel : IRazorContentModel
    {
        EmailAddress FromEmailAddress { get; }
        EmailAddressCollection ToEmailAddressCollection { get; }
        EmailAddressCollection CcEmailAddressCollection { get; }
        EmailAddressCollection BccEmailAddressCollection { get; }
        MailMessageAttachmentCollection Attachments { get; }
        MailPriority Priority { get; }
    }
}
