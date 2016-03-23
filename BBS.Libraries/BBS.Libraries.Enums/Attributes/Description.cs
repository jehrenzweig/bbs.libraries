using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace BBS.Libraries.Enums.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = false)]
    public class Description : System.ComponentModel.DescriptionAttribute
    {
        public Description(string value) : base(value)
        {
        }

        public static string GetDescription(Enum value)
        {
            var attribute = Helpers.GetAttributes<Description>(value).FirstOrDefault();
            if (attribute != null)
                return attribute.Description;
            return value.ToString();
        }
    }
}
