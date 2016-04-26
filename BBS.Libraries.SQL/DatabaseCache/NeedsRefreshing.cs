using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.SQL
{
    public static partial class DatabaseCache<T>
    {
        private static bool NeedsRefreshing(string cacheId)
        {
            if (!Items.ContainsKey(cacheId))
            {
                throw new ArgumentException("Non Existing");
            }

            var item = Items[cacheId];

            var timeDiff = DateTime.UtcNow - item.InsertedIntoCacheDateTime;

            if (timeDiff > new TimeSpan(0, 0, 10, 0))
            {
                return true;
            }

            return false;
        }
    }
}
