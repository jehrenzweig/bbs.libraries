using System.Data;
using System.Threading.Tasks;

namespace BBS.Libraries.SQL
{
    public partial class Command
    {
        public Task<object> ExecuteSclarAsync()
        {
            return GenerateSqlCommand().ExecuteScalarAsync();
        }
        public object ExecuteScalar()
        {
            return GenerateSqlCommand().ExecuteScalar();
        }
        public object ExecuteScalarInTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
        {
            return ExecuteInTransaction<object>(ExecuteScalar, isolationLevel);
        }
    }
}
