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

using System;
using BBS.Libraries.Templating.Resolvers;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace BBS.Libraries.Templating.Razor
{
    public class RazorTemplatingService<T> : BBS.Libraries.Templating.ITemplateService<T>
    {
        public ITemplateResolver Resolver { get; set; }
        

        public RazorTemplatingService(string namespaceViewName)
        {
            // TODO: Add in config switch for the type to resolve to
            Resolver = new VirtualFileResolver(namespaceViewName);
        }

        public string Parse<T>(string templateToParse, T model)
        {
            var configuration = new TemplateServiceConfiguration
            {
                CachingProvider = new DefaultCachingProvider(),
                // TODO: Add in config for turning debug on / off
                Debug = true,
                Language = Language.CSharp,
            };

            var service = RazorEngineService.Create(configuration);

            return service.RunCompile(templateToParse, Guid.NewGuid().ToString(), typeof (T), model);
        }
    }
}
