using System;
using System.Web;
using System.Web.Mvc;
using RazorEngine.Templating;

namespace BBS.Libraries.Razor
{
    public class VirtualFileResolver : ITemplateResolver
    {
        #region Properties

        /// <summary>
        /// Gets the <see cref="HtmlHelper{TModel}"/> for this template.
        /// </summary>
        public HtmlHelper<object> Html { get; private set; }

        /// <summary>
        /// Gets the <see cref="UrlHelper"/> for this template.
        /// </summary>
        public UrlHelper Url { get; private set; }

        #endregion

        #region Methods

        public void InitHelpers()
        {
            var httpContext = new HttpContextWrapper(HttpContext.Current);
            var handler = httpContext.CurrentHandler as MvcHandler;
            if (handler == null)
                throw new InvalidOperationException("Unable to run template outside of ASP.NET MVC");
        }

        #endregion

        public string NameSpace { get; private set; }

        public VirtualFileResolver(string @namespace)
        {
            this.NameSpace = @namespace;
        }

        public string Resolve(string fileName)
        {
            var ss = new BBS.Libraries.IO.Virtual.LocalVirtualFile(NameSpace, fileName);

            return ss.ToString();
        }
    }
}