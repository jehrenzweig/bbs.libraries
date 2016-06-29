namespace BBS.Libraries.Templating
{
    public interface ITemplateResolver
    {
        string Resolve(string objectToResolve);
    }
}