//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Linq;
//using System.Net.Mail;
//using System.Text;
//using System.Threading.Tasks;

//namespace BBS.Libraries.Contracts
//{
//    public interface IMailMessage
//    {

//        EmailAddress From { get; set; }


//        EmailAddress Sender { get; set; }


//        EmailAddressCollection ReplyToList { get; set; }


//        EmailAddressCollection To { get; set; }


//        EmailAddressCollection CC { get; set; }


//        EmailAddressCollection Bcc { get; set; }


//        MailPriority Priority { get; set; }


//        DeliveryNotificationOptions DeliveryNotificationOptions { get; set; }


//        string Subject { get; set; }


//        int? SubjectEncoding { get; set; }
        
//        NameValueCollection Headers { get; }


//        int? HeadersEncoding { get; set; }


//        string Body { get; set; }


//        int? BodyEncoding { get; set; }


//        bool IsBodyHtml { get; set; }


//        MailMessageAttachmentCollection Attachments { get; set; }


//        MailMessageAlternateViewCollection AlternateViews { get; set; }
//    }
//}
