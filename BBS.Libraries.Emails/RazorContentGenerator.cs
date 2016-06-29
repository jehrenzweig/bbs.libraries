using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using BBS.Libraries.Contracts;
using BBS.Razor;


namespace BBS.Libraries.Emails
{
    public class RazorContentGenerator<T> where T : class, IEmailBaseModel //: RazorGenerator<T, MailMessage> where T : class, IEmailBaseModel
    {
        private readonly BBS.Libraries.Templating.ITemplateService<T> templateService;

        private string NamespaceViewName { get; set; }

        public virtual string SubjectViewFileName { get; set; }
        public virtual string PlainViewFileName { get; set; }
        public virtual string MhtmlViewFileName { get; set; }
        

        public RazorContentGenerator(
            string namespaceViewName, 
            string subjectViewFileName, 
            string plainViewFileName,
            string mhtmlViewFileName) 
        {
            this.NamespaceViewName = namespaceViewName;
            this.SubjectViewFileName = subjectViewFileName;
            this.PlainViewFileName = plainViewFileName;
            this.MhtmlViewFileName = mhtmlViewFileName;

            templateService = new RazorTemplatingService<T>(namespaceViewName);
        }

        public string SubjectView(IEmailBaseModel model)
        {
            if (!string.IsNullOrWhiteSpace(this.SubjectViewFileName))
            {
                return templateService.Parse(templateService.Resolver.Resolve(this.SubjectViewFileName), model);
            }
            return string.Empty;
        }

        public string PlainView(IEmailBaseModel model)
        {
            if (!string.IsNullOrWhiteSpace(this.PlainViewFileName))
            {
                return templateService.Parse(templateService.Resolver.Resolve(this.PlainViewFileName), model);
            }
            return string.Empty;
        }

        public string MhtmlView(IEmailBaseModel model)
        {
            if (!string.IsNullOrWhiteSpace(this.MhtmlViewFileName))
            {
                return templateService.Parse(templateService.Resolver.Resolve(this.MhtmlViewFileName), model);
            }
            return string.Empty;
        }

        public MailMessage Generate(T model)
        {
            var mhtmlViewAlternateView = AlternateView.CreateAlternateViewFromString(MhtmlView(model), new ContentType("text/html"));
            var plainViewAlternateView = AlternateView.CreateAlternateViewFromString(PlainView(model));

            return new MailMessage()
            {
                Subject = this.SubjectView(model),
                AlternateViews = new MailMessageAlternateViewCollection() {plainViewAlternateView, mhtmlViewAlternateView},
                To = model.ToEmailAddressCollection,
                From = model.FromEmailAddress,
                CC = model.CcEmailAddressCollection ?? new EmailAddressCollection(),
                Bcc = model.BccEmailAddressCollection ?? new EmailAddressCollection(),
                Attachments = model.Attachments ?? new MailMessageAttachmentCollection(),
                Priority = model.Priority
            };
        }
    }
}