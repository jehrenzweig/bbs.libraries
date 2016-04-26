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
        public static Guid? GetGuidNullable(this SqlDataReader reader, string columnName)
        {
            if (reader.IsColumnDbNull(columnName))
            {
                return null;
            }

            return reader.GetGuid(reader.GetOrdinal(columnName));
        }
    }
}
