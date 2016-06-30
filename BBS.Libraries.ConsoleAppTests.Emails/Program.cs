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
using System.Linq;
using BBS.Libraries.Emails;
using BBS.Libraries.Templating.Handlebars;
using BBS.Libraries.Templating.Razor;

namespace BBS.Libraries.ConsoleAppTests.Emails
{
    /// <summary>
    /// Email data to be used across all test cases
    /// </summary>
    static class TestData
    {
        public static IEnumerable<string> ToEmailAddresses = new[] { "brenton@helpfulcowz.com" };
        public static IEnumerable<string> FromEmailAddresses = new[] { "someone@somewhere.net" };
        public static string FirstName = "Brenton";
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Generate and send an email

            var razorModel = new Models.Razor01
            {
                ToEmailAddressCollection = new BBS.Libraries.Emails.EmailAddressCollection(TestData.ToEmailAddresses.First()),
                FromEmailAddress = new EmailAddress(TestData.FromEmailAddresses.First()),
                FirstName = TestData.FirstName
            };

            var razorEngine = new RazorContentEmailGenerator<Models.Razor01>(
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.RepositryNamespace,
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.Views.Razor._01_Subject_cshtml,
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.Views.Razor._01_PlainText_cshtml,
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.Views.Razor._01_Mhtml_cshtml
            );

            razorEngine.GenerateAndSend(razorModel);

            // HandleBars

            var handleBarsModel = new Models.HandleBars01
            {
                ToEmailAddressCollection = new BBS.Libraries.Emails.EmailAddressCollection(TestData.ToEmailAddresses.First()),
                FromEmailAddress = new EmailAddress(TestData.FromEmailAddresses.First()),
                FirstName = TestData.FirstName
            };

            var handleBarsEngine = new HandlebarsContentEmailGenerator<Models.HandleBars01>(
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.RepositryNamespace,
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.Views.HandleBars._01_Subject_cshtml,
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.Views.HandleBars._01_PlainText_cshtml,
                BBS.Libraries.ConsoleAppTests.Emails.T4Files.Views.HandleBars._01_Mhtml_cshtml
            );

            handleBarsEngine.GenerateAndSend(handleBarsModel);

            // Batch size of Handlebars ;)

            var models = GenerateTester.GetEmailModels().ToList();
            handleBarsEngine.GenerateAndSend(models, 5);
        }
    }

    class GenerateTester
    {
        public static IEnumerable<IEmailBaseModel> GetEmailModels()
        {
            for (int i = 0; i < 13; i++)
            {
                yield return new Models.HandleBars01
                {
                    ToEmailAddressCollection = new BBS.Libraries.Emails.EmailAddressCollection("brenton@helpfulcowz.com"),
                    FromEmailAddress = new EmailAddress("someone@somewhere.net"),
                    FirstName = "Brenton"
                };
            }
        }
    }
}
