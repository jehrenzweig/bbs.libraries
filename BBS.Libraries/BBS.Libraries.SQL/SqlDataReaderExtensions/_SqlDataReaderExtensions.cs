using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.SQL
{
    public static partial class SqlDataReaderExtensions
    {
        static SqlDataReaderExtensions() { }

        private static bool IsColumnDbNull(this SqlDataReader reader, string columnName)
        {
            return reader[columnName] == DBNull.Value;
        }
    }
}
