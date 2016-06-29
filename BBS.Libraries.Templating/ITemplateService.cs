using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Templating
{
    public interface ITemplateService
    {
        ITemplateResolver Resolver { get; set; }
    }

    public interface ITemplateService<T> : ITemplateService
    {
        string Parse<T>(string templateToParse, T model);
    }
}
