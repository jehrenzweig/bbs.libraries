using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BBS.Libraries.SQL
{
    public partial class Command : IDisposable
    {
        public string Database => Connection.Database;
        public int PacketSize => Connection.PacketSize;
        public string ServerVersion => Connection.ServerVersion;
        public Guid ClientConnectionId => Connection.ClientConnectionId;
        public int ConnectionTimeout => Connection.ConnectionTimeout;
        public string WorkstationId => Connection.WorkstationId;
        public ConnectionState ConnectionState => Connection.State;

        public bool StatisticsEnabled
        {
            get { return Connection.StatisticsEnabled; }
            set { Connection.StatisticsEnabled = value; }
        }
        private SqlConnection Connection { get; set; }
        private StringBuilder CommandText { get; set; }
        private List<SqlParameter> ParameterCollection { get; set; }
        private SqlDataReader _reader;
        public SqlTransaction Transaction { get; set; }
        public bool HasRows
        {
            get
            {
                if (_reader == null)
                {
                    _reader = GenerateSqlCommand().ExecuteReader();
                }
                return _reader.HasRows;
            }
        }
        public SqlDataReader Reader
        {
            get
            {
                if (_reader == null)
                {
                    _reader = GenerateSqlCommand().ExecuteReader();
                }
                return _reader;
            }
        }
        private static readonly Regex TrailingCommaRegex = new Regex("(?<FullOperator>\\s*(?<Operator>,)(?<LineSuffix>\\s*))$", RegexOptions.IgnoreCase | RegexOptions.ECMAScript);
        private static readonly Regex TrailingWhereAndOrRegex = new Regex("(?<FullOperator>(?<LinePrefix>\\s+)(?<Operator>where|and|or)(?<LineSuffix>\\s*))$", RegexOptions.IgnoreCase | RegexOptions.ECMAScript);
        private static readonly Regex TrailingUnionRegex = new Regex("(?<FullOperator>\\s+(?<Operator>(union)|(union\\sall))(?<LineSuffix>\\s*))$", RegexOptions.IgnoreCase | RegexOptions.ECMAScript);


        public Command(string connectionString)
        {
            Connection = new SqlConnection(connectionString);

            CommandText = new StringBuilder();

            ParameterCollection = new List<SqlParameter>();

            Connection.Open();
        }
        private bool ExecuteInTransaction<T>(Func<T> actionToRun, IsolationLevel isolationLevel)
        {
            if (Transaction != null)
            {
                throw new ArgumentException("There is a transaction already open on this command object");
            }

            var result = false;

            var transactionId = Guid.NewGuid().ToString("N");

            Transaction = Connection.BeginTransaction(isolationLevel, transactionId);

            try
            {
                actionToRun.Invoke();

                Transaction.Commit();

                result = true;
            }
            catch (SqlException exception)
            {
                Transaction.Rollback();

                Transaction = null;

                throw;
            }
            return result;
        }
        private SqlCommand GenerateSqlCommand()
        {
            var result = new SqlCommand(CommandText.ToString(), Connection);

            if (Transaction != null)
            {
                result.Transaction = Transaction;
            }

            result.Parameters.AddRange(ParameterCollection.ToArray());

            return result;
        }

        public void Dispose()
        {
            CommandText.Clear();
            ParameterCollection.Clear();
            Connection.Close();
        }
        public override string ToString()
        {
            var result = CommandText.ToString();

            foreach (var sqlParameter in ParameterCollection)
            {
                if (result.Contains(sqlParameter.ParameterName))
                {
                    switch (sqlParameter.DbType)
                    {
                        case DbType.AnsiString:
                        case DbType.AnsiStringFixedLength:
                        case DbType.Date:
                        case DbType.DateTime:
                        case DbType.DateTime2:
                        case DbType.DateTimeOffset:
                        case DbType.Guid:
                        case DbType.String:
                        case DbType.StringFixedLength:
                        case DbType.Time:
                            result = result.Replace(sqlParameter.ParameterName, $"'{sqlParameter.Value.ToString()}'");
                            break;
                        default:
                            result = result.Replace(sqlParameter.ParameterName, $"{sqlParameter.Value.ToString()}");
                            break;
                    }


                }
            }

            return result;
        }
    }
}
