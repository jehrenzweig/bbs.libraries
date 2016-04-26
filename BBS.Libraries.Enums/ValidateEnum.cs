using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Enums
{
    public class Validators
    {
        public static Array ValidateEnum<T>()
        {
            var enumType = typeof(T);
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be type System.Enum");

            return enumType.GetEnumValues();
        }
    }
}
