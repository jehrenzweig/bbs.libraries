﻿//-----------------------------------------------------------------------
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using BBS.Libraries.Emails;
using MailMessage = BBS.Libraries.Emails.MailMessage;

namespace BBS.Libraries.Templating.Handlebars
{
    public class HandlebarsContentEmailGenerator<T> : EmailGenerator<T> where T : class, IEmailBaseModel
    {
        public HandlebarsContentEmailGenerator(
            string namespaceViewName,
            string subjectViewFileName,
            string plainViewFileName,
            string mhtmlViewFileName)
        {
            this.NamespaceViewName = namespaceViewName;
            this.SubjectViewFileName = subjectViewFileName;
            this.PlainViewFileName = plainViewFileName;
            this.MhtmlViewFileName = mhtmlViewFileName;

            _templateService = new HandleBarsTemplatingService<T>(namespaceViewName);
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
