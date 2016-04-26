using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.Serialization;
using BBS.Libraries.Extensions;

namespace BBS.Libraries.Emails
{
  public class MailMessageAttachmentCollection : List<MailMessageAttachment>
  {
    public void Add(System.IO.Stream stream, string fileName, string mediaType)
    {
      base.Add(new MailMessageAttachment() { Content = stream.ToByteArray(), ContentType = mediaType, Name = fileName });
    }

    public void Add(System.Net.Mail.Attachment attachment)
    {
      base.Add(new MailMessageAttachment(){Content = attachment.ContentStream.ToByteArray(), ContentType = attachment.ContentType.MediaType, Name = attachment.Name});
    }
  }
}