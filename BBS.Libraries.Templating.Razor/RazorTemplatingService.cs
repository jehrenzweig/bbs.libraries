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
            var configuration = new TemplateServiceConfiguration()
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
