using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBS.Libraries.Emails;
using BBS.Libraries.Templating.Handlebars;
using BBS.Libraries.Templating.Razor;

namespace BBS.Libraries.ConsoleAppTests.Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate and send an email

            var razorModel = new Models.Razor01()
            {
                ToEmailAddressCollection = new BBS.Libraries.Emails.EmailAddressCollection("brenton@helpfulcowz.com"),
                FromEmailAddress = new EmailAddress("someone@somewhere.net"),
                FirstName = "Brenton"
            };

            var razorEngine = new RazorContentEmailGenerator<Models.Razor01>(
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.RepositryNamespace,
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.Views.Razor._01_Subject_cshtml,
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.Views.Razor._01_PlainText_cshtml,
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.Views.Razor._01_Mhtml_cshtml
                );

            razorEngine.GenerateAndSend(razorModel);

            // HandleBars

            var handleBarsModel = new Models.HandleBars01()
            {
                ToEmailAddressCollection = new BBS.Libraries.Emails.EmailAddressCollection("brenton@helpfulcowz.com"),
                FromEmailAddress = new EmailAddress("someone@somewhere.net"),
                FirstName = "Brenton"
            };

            var handleBarsEngine = new HandlebarsContentEmailGenerator<Models.HandleBars01>(
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.RepositryNamespace,
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.Views.HandleBars._01_Subject_cshtml,
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.Views.HandleBars._01_PlainText_cshtml,
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.Views.HandleBars._01_Mhtml_cshtml
                );

            handleBarsEngine.GenerateAndSend(handleBarsModel);
        }
    }
}
