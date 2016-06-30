//-----------------------------------------------------------------------
//    MIT License
//
//    Copyright (c) Wednesday, June 29, 2016 1:15:39 PM Betabyte Software
//
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the "Software"), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:
//
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.

//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//    SOFTWARE.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using BBS.Libraries.Extensions;

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

        protected virtual BBS.Libraries.Emails.MailMessage Generate(IEmailBaseModel emailModel)
        {
            var mhtmlViewAlternateView = AlternateView.CreateAlternateViewFromString(MhtmlView(emailModel), new ContentType("text/html"));
            var plainViewAlternateView = AlternateView.CreateAlternateViewFromString(PlainView(emailModel));

            return new MailMessage
            {
                Subject = this.SubjectView(emailModel),
                AlternateViews = new MailMessageAlternateViewCollection { plainViewAlternateView, mhtmlViewAlternateView },
                To = emailModel.ToEmailAddressCollection,
                From = emailModel.FromEmailAddress,
                CC = emailModel.CcEmailAddressCollection ?? new EmailAddressCollection(),
                Bcc = emailModel.BccEmailAddressCollection ?? new EmailAddressCollection(),
                Attachments = emailModel.Attachments ?? new MailMessageAttachmentCollection(),
                Priority = emailModel.Priority
            };
        }

        public void GenerateAndSend<T>(IEnumerable<T> emailModel, int batchSize) where T : IEmailBaseModel
        {
            emailModel.RunInBatches(batchSize, emailModelBatch =>
            {
                foreach (var model in emailModelBatch)
                {
                    GenerateAndSend(model);
                }
            });
        }

        public void GenerateAndSend<T>(T emailModel) where T : IEmailBaseModel
        {
            var email = Generate(emailModel);
            Send(email);
        }
    }
}
