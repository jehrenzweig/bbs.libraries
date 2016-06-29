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
        protected string NamespaceViewName { get; set; }
        protected string SubjectViewFileName { get; set; }
        protected string PlainViewFileName { get; set; }
        protected string MhtmlViewFileName { get; set; }

        protected BBS.Libraries.Templating.ITemplateService<T> _templateService;
        protected string SubjectView(IEmailBaseModel model)
        {
            if (!string.IsNullOrWhiteSpace(this.SubjectViewFileName))
            {
                return _templateService.Parse(_templateService.Resolver.Resolve(this.SubjectViewFileName), model);
            }
            return string.Empty;
        }

        protected string PlainView(IEmailBaseModel model)
        {
            if (!string.IsNullOrWhiteSpace(this.PlainViewFileName))
            {
                return _templateService.Parse(_templateService.Resolver.Resolve(this.PlainViewFileName), model);
            }
            return string.Empty;
        }

        protected string MhtmlView(IEmailBaseModel model)
        {
            if (!string.IsNullOrWhiteSpace(this.MhtmlViewFileName))
            {
                return _templateService.Parse(_templateService.Resolver.Resolve(this.MhtmlViewFileName), model);
            }
            return string.Empty;
        }

        protected abstract BBS.Libraries.Emails.MailMessage Generate(IEmailBaseModel emailModel);

        public void GenerateAndSend<T>(T emailModel) where T : IEmailBaseModel
        {
            var email = Generate(emailModel);
            Send(email);
        }
    }
}
