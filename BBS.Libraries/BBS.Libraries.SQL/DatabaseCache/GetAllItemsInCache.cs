using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.SQL
{
    public static partial class DatabaseCache<T>
    {
        public static Dictionary<string, T> GetAllItemsInCache()
        {
            var result = new Dictionary<string, T>();

            foreach (var item in Items)
            {
                result.Add(item.Key, item.Value.Item);
            }

            return result;
        }
    }
}
