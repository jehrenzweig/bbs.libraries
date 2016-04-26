using System;
using System.IO;
using System.Net.Mail;

namespace BBS.Libraries.Emails
{
    public class MailMessageAlternateView
    {

        private AlternateView _alternateView;

        public byte[] Content { get; set; }

        public string ContentType { get; set; }

        public AlternateView XAlternateView
        {
            get
            {
                if (_alternateView == null)
                {
                    return _alternateView = new AlternateView(new MemoryStream(Content), ContentType);
                }
                else
                {
                    return _alternateView;
                }
            }
            set
            {
                if (_alternateView == null)
                {
                    var cs = this.Content;
                    _alternateView = new AlternateView(new MemoryStream(cs), ContentType);
                }
            }
        }

    }
}