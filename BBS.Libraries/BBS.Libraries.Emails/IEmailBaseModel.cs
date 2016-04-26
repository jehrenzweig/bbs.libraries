using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BBS.Libraries.Emails;

namespace BBS.Libraries.Contracts
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
