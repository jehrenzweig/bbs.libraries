using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.SQL
{
    public static partial class DatabaseCache<T>
    {
        private static Dictionary<string, DatabaseCacheItem<T>> Items { get; set; }

        static DatabaseCache()
        {
            Items = new Dictionary<string, DatabaseCacheItem<T>>();
        }
    }
}