using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBS.Libraries.Templating.Resolvers;
using HandlebarsDotNet;

namespace BBS.Libraries.Templating.Handlebars
{
    public class HandleBarsTemplatingService<T> : BBS.Libraries.Templating.ITemplateService<T>
    {
        public HandleBarsTemplatingService(string namespaceViewName)
        {
            // TODO: Add in config switch for the type to resolve to
            Resolver = new VirtualFileResolver(namespaceViewName);
        } 

        public string Parse<T>(string templateToParse, T model)
        {
            var template = HandlebarsDotNet.Handlebars.Compile(templateToParse);
            return template(model);
        }

        public ITemplateResolver Resolver { get; set; }
    }
}
