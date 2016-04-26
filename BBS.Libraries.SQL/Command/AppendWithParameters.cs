using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.SQL
{
    public partial class Command
    {
        public void AppendWithParameters(string sqlString, params object[] args)
        {
            var sqlParms = new List<SqlParameter>();

            for (int i = 0; i < args.Count(); i++)
            {
                var guid = Guid.NewGuid().ToString("N");
                var sqlParameterName = $"@{guid}";

                var sqlFormatReplacement = "{" + i + "}";

                sqlString = sqlString.Replace(sqlFormatReplacement, sqlParameterName);

                var argument = args[i];

                if (argument == null)
                {
                    argument = DBNull.Value;
                }

                sqlParms.Add(new SqlParameter(sqlParameterName, argument));
            }

            AppendWithParameters(sqlString, sqlParms.ToArray());
        }
        public void AppendWithParameters(string value, SqlParameter values)
        {
            Append(value);
            ParameterCollection.Add(values);
        }
        public void AppendWithParameters(string value, SqlParameter[] values)
        {
            Append(value);
            ParameterCollection.AddRange(values);
        }
    }
}
