using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Enums.Attributes
{
    public static class Helpers
    {
        public static T[] GetAttributes<T>(Enum value) where T : class
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (T[])fieldInfo.GetCustomAttributes(typeof(T), false);
            return attributes;
        }
    }
}
