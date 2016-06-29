using System.Net.Mail;
using System.Net.Mime;
using BBS.Libraries.Emails;
using MailMessage = BBS.Libraries.Emails.MailMessage;

namespace BBS.Libraries.Templating.Razor
{
    public class RazorContentEmailGenerator<T> : EmailGenerator<T> where T : class, IEmailBaseModel
    {
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
