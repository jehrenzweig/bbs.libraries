using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.Serialization;
using BBS.Libraries.Extensions;

namespace BBS.Libraries.Emails
{
    public class MailMessageAlternateViewCollection : List<MailMessageAlternateView>
    {
        public void Add(System.Net.Mail.AlternateView alternate)
        {
            base.Add(new MailMessageAlternateView()
            {
                Content = alternate.ContentStream.ToByteArray(),
                ContentType = alternate.ContentType.MediaType
            });
        }
    }
}