using System;
using BBS.Libraries.Templating.Resolvers;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using ITemplateResolver = BBS.Libraries.Templating.ITemplateResolver;

namespace BBS.Razor
{
    public class RazorTemplatingService<T> : BBS.Libraries.Templating.ITemplateService<T>
    {
        public ITemplateResolver Resolver { get; set; }
        

        public RazorTemplatingService(string namespaceViewName)
        {
            Resolver = new VirtualFileResolver(namespaceViewName);
        }

        public string Parse<T>(string templateToParse, T model)
        {
            var configuration = new TemplateServiceConfiguration()
            {
                CachingProvider = new DefaultCachingProvider(),
                Debug = true,
                Language = Language.CSharp,
            };

            var service = RazorEngineService.Create(configuration);

            return service.RunCompile(templateToParse, Guid.NewGuid().ToString(), typeof (T), model);
        }
    }
}
