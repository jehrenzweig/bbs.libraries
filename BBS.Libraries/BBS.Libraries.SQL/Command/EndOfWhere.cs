using System;
using System.Text.RegularExpressions;

namespace BBS.Libraries.SQL
{
    public partial class Command
    {
        public bool EndOfWhere()
        {
            return EndOfWhere(string.Empty);
        }

        public bool EndOfWhere(string replaceWith)
        {
            bool flag = false;
            string input = CommandText.ToString();
            Match match = TrailingWhereAndOrRegex.Match(input);
            if (match.Success)
            {
                CommandText.Clear();
                CommandText.Append(input.Remove(input.Length - match.Groups["FullOperator"].Length, match.Groups["FullOperator"].Length));
                if (match.Groups["Operator"].Value.Equals("where", StringComparison.InvariantCultureIgnoreCase))
                {
                    CommandText.Append(match.Groups["LinePrefix"].Value);
                }
                CommandText.Append(replaceWith);
                CommandText.Append(match.Groups["LineSuffix"].Value);
                flag = true;
            }
            return flag;
        }
    }
}