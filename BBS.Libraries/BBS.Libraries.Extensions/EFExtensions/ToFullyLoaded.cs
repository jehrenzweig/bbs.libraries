using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
    public partial class EFExtensions
    {
        public static List<T> ToFullyLoaded<T>(this IQueryable<T> items)
        {
            return items.ToArray().ToList();
        }
    }
}
