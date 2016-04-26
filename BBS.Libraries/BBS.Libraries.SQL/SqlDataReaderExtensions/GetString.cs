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
        public static string GetString(this SqlDataReader reader, string columnName)
        {
            return !reader.IsColumnDbNull(columnName) ? reader.GetString(reader.GetOrdinal(columnName)) : string.Empty;
        }
    }
}
