namespace BBS.Libraries.SQL
{
    public partial class Command
    {
        public bool EndOfList()
        {
            return EndOfList(string.Empty);
        }

        public bool EndOfList(string replaceWith)
        {
            bool flag = false;
            string input = CommandText.ToString();
            var match = TrailingCommaRegex.Match(input);
            if (match.Success)
            {
                CommandText.Clear();
                CommandText.Append(input.Remove(input.Length - match.Groups["FullOperator"].Length, match.Groups["FullOperator"].Length));
                CommandText.Append(replaceWith);
                CommandText.Append(match.Groups["LineSuffix"].Value);
                flag = true;
            }
            return flag;
        }
    }
}