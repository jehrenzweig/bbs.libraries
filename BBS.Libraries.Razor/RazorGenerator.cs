using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBS.Libraries.Contracts;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace BBS.Libraries.Razor
{
    public class RazorGenerator<T> where T : class, IRazorContentModel
    {
        private static ITemplateService _templateService;

        protected virtual string NamespaceViewName { get; set; }

        protected ITemplateService TemplateService
        {
            get
            {
                ITemplateService templateService = _templateService;
                if (_templateService != null)
                {
                    return _templateService;
                }
                return _templateService = (ITemplateService)new TemplateService((ITemplateServiceConfiguration)new TemplateServiceConfiguration()
                {
                    Resolver = (ITemplateResolver)new VirtualFileResolver(this.NamespaceViewName),
                });
            }
        }

        protected RazorGenerator(string namespaceViewName)
        {
            this.NamespaceViewName = namespaceViewName;
        }

        public virtual void Generate(T model)
        {
            throw new NotImplementedException();
        }
    }
    public class RazorGenerator<T, U> : RazorGenerator<T> where T : class, IRazorContentModel
    {
        protected RazorGenerator(string namespaceViewName) : base(namespaceViewName)
        {
        }

        public virtual U Generate(T model)
        {
            throw new NotImplementedException();
        }
    }
}
