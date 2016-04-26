using System.Collections;

namespace BBS.Libraries.SQL
{
    public partial class Command
    {
        public IDictionary RetrieveStatistics()
        {
            return Connection.RetrieveStatistics();
        }
    }
}
