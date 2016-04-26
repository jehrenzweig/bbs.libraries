using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.SQL
{
    public static partial class DatabaseCache<T>
    {
        public static T GetOrInsert(string cacheId, Func<T> queryToRun)
        {
            if (Items.ContainsKey(cacheId))
            {
                if (NeedsRefreshing(cacheId))
                {
                    Items[cacheId].Item = queryToRun.Invoke();
                    Items[cacheId].InsertedIntoCacheDateTime = DateTime.UtcNow;
                }

                return Items[cacheId].Item;
            }

            Items.Add(cacheId, new DatabaseCacheItem<T>()
            {
                InsertedIntoCacheDateTime = DateTime.UtcNow,
                Item = queryToRun.Invoke()
            });

            return Items[cacheId].Item;
        }
    }
}
