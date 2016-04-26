using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Emails
{
    public class MailMessageAttachment
    {
        private Attachment _attachment;

        public byte[] Content { get; set; }

        public string ContentType { get; set; }

        public string Name { get; set; }

        public Attachment XAttachment
        {
            get
            {
                if (_attachment == null)
                {
                    return _attachment = new Attachment(new MemoryStream(Content), Name, ContentType);
                }
                else
                {
                    return _attachment;
                }
            }
            set
            {
                if (_attachment == null)
                {
                    _attachment = new Attachment(new MemoryStream(Content), Name, ContentType);
                }
            }
        }
    }
}
