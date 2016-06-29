using System.Net.Mail;
using System.Net.Mime;
using BBS.Libraries.Emails;
using MailMessage = BBS.Libraries.Emails.MailMessage;

namespace BBS.Libraries.Templating.Razor
{
    public class RazorContentEmailGenerator<T> : EmailGenerator<T> where T : class, IEmailBaseModel
    {
        private readonly BBS.Libraries.Templating.ITemplateService<T> _templateService;
        private string NamespaceViewName { get; set; }
        private string SubjectViewFileName { get; set; }
        private string PlainViewFileName { get; set; }
        private string MhtmlViewFileName { get; set; }
        
        public RazorContentEmailGenerator(
            string namespaceViewName,
            string subjectViewFileName,
            string plainViewFileName,
            string mhtmlViewFileName)
        {
            this.NamespaceViewName = namespaceViewName;
            this.SubjectViewFileName = subjectViewFileName;
            this.PlainViewFileName = plainViewFileName;
            this.MhtmlViewFileName = mhtmlViewFileName;

            _templateService = new RazorTemplatingService<T>(namespaceViewName);
        }

        private string SubjectView(IEmailBaseModel model)
        {
            if (!string.IsNullOrWhiteSpace(this.SubjectViewFileName))
            {
                return _templateService.Parse(_templateService.Resolver.Resolve(this.SubjectViewFileName), model);
            }
            return string.Empty;
        }

        private string PlainView(IEmailBaseModel model)
        {
            if (!string.IsNullOrWhiteSpace(this.PlainViewFileName))
            {
                return _templateService.Parse(_templateService.Resolver.Resolve(this.PlainViewFileName), model);
            }
            return string.Empty;
        }

        private string MhtmlView(IEmailBaseModel model)
        {
            if (!string.IsNullOrWhiteSpace(this.MhtmlViewFileName))
            {
                return _templateService.Parse(_templateService.Resolver.Resolve(this.MhtmlViewFileName), model);
            }
            return string.Empty;
        }
        
        protected override MailMessage Generate(IEmailBaseModel emailModel)
        {
            var mhtmlViewAlternateView = AlternateView.CreateAlternateViewFromString(MhtmlView(emailModel), new ContentType("text/html"));
            var plainViewAlternateView = AlternateView.CreateAlternateViewFromString(PlainView(emailModel));

            return new MailMessage()
            {
                Subject = this.SubjectView(emailModel),
                AlternateViews = new MailMessageAlternateViewCollection() { plainViewAlternateView, mhtmlViewAlternateView },
                To = emailModel.ToEmailAddressCollection,
                From = emailModel.FromEmailAddress,
                CC = emailModel.CcEmailAddressCollection ?? new EmailAddressCollection(),
                Bcc = emailModel.BccEmailAddressCollection ?? new EmailAddressCollection(),
                Attachments = emailModel.Attachments ?? new MailMessageAttachmentCollection(),
                Priority = emailModel.Priority
            };
        }
    }
}
