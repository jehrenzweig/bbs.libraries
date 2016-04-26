using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.SQL
{
    public static partial class DatabaseCache<T>
    {
        public static void Remove(string cacheId)
        {
            if (Items.ContainsKey(cacheId))
            {
                Items.Remove(cacheId);
            }
        }
    }
}
