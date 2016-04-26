using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.SQL
{
    public static partial class DatabaseCache<T>
    {
        public static T Update(string cacheId, Func<T> queryToRun)
        {
            if (!Items.ContainsKey(cacheId))
            {
                return GetOrInsert(cacheId, queryToRun);
            }
            var itemToUpdate = Items[cacheId];

            itemToUpdate.Item = queryToRun.Invoke();
            itemToUpdate.InsertedIntoCacheDateTime = DateTime.UtcNow;

            return itemToUpdate.Item;
        }
    }
}
