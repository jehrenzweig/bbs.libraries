using System;

namespace BBS.Libraries.SQL
{
    public class DatabaseCacheItem<T>
    {
        public T Item { get; set; }
        public DateTime InsertedIntoCacheDateTime { get; set; }
    }
}