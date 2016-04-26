using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.SQL
{
    public partial class Command
    {
        public Task<int> ExecuteNonQueryAsync()
        {
            return GenerateSqlCommand().ExecuteNonQueryAsync();
        }
        public bool ExecuteNonQuery()
        {
            return GenerateSqlCommand().ExecuteNonQuery() > 0;
        }
        public bool ExecuteNonQueryInTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
        {
            return ExecuteInTransaction<bool>(ExecuteNonQuery, isolationLevel);
        }
    }
}
