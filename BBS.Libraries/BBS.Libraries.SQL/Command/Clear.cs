namespace BBS.Libraries.SQL
{
    public partial class Command
    {
        public void Clear()
        {
            CommandText.Clear();
            ParameterCollection.Clear();

            if (_reader != null)
            {
                _reader.Close();
                _reader = null;
            }

            Transaction = null;
        }
    }
}