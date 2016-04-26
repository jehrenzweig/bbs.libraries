using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Web.Razor;
using System.Web.Razor.Parser;
using BBS.Libraries.Contracts;
using BBS.Libraries.Extensions;
using BBS.Libraries.Razor;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using System.Web.WebPages;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using CSharpRazorCodeLanguage = RazorEngine.Compilation.CSharp.CSharpRazorCodeLanguage;
using RazorEngineHost = RazorEngine.Compilation.RazorEngineHost;

namespace BBS.Libraries.Emails
{
    public class RazorContentGenerator<T> : RazorGenerator<T, MailMessage> where T : class, IEmailBaseModel
    {
        public static ITemplateService _templateService;

        public ITemplateService TemplateService
        {
            get
            {
                ITemplateService templateService = _templateService;
                if (_templateService != null)
                {
                    return _templateService;
                }
                return
                    _templateService =
                        (ITemplateService)
                            new TemplateService((ITemplateServiceConfiguration) new TemplateServiceConfiguration()
                            {
                                Resolver = (ITemplateResolver) new VirtualFileResolver(this.NamespaceViewName),
                            });
            }
        }

        private VirtualFileResolver _virtualFileResolver => new VirtualFileResolver(this.NamespaceViewName);

        public virtual string SubjectViewFileName { get; set; }
        public virtual string PlainViewFileName { get; set; }
        public virtual string MhtmlViewFileName { get; set; }

        public RazorContentGenerator(string namespaceViewName, string subjectViewFileName, string plainViewFileName,
            string mhtmlViewFileName) : base(namespaceViewName)
        {
            this.SubjectViewFileName = subjectViewFileName;
            this.PlainViewFileName = plainViewFileName;
            this.MhtmlViewFileName = mhtmlViewFileName;
        }

        public string SubjectView(IEmailBaseModel model)
        {
            string str = string.Empty;
            if (!string.IsNullOrWhiteSpace(this.SubjectViewFileName))
            {
                str = TemplateService.Parse(_virtualFileResolver.Resolve(this.SubjectViewFileName), model, null, null);
            }
            return str;
        }

        public string PlainView(IEmailBaseModel model)
        {
            string str = string.Empty;
            if (!string.IsNullOrWhiteSpace(this.PlainViewFileName))
            {
                str = this.TemplateService.Parse(_virtualFileResolver.Resolve(this.PlainViewFileName), model, null, null);
            }
            return str;
        }

        public string MhtmlView(IEmailBaseModel model)
        {
            string str = string.Empty;
            if (!string.IsNullOrWhiteSpace(this.MhtmlViewFileName))
            {
                str = this.TemplateService.Parse(_virtualFileResolver.Resolve(this.MhtmlViewFileName), model, null, null);
            }
            return str;
        }

        public override MailMessage Generate(T model)
        {
            var mhtmlViewAlternateView = AlternateView.CreateAlternateViewFromString(MhtmlView(model),
                new ContentType("text/html"));
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