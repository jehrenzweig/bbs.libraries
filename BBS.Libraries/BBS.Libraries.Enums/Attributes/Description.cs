using System;
using System.ComponentModel;
using System.Reflection;

namespace BBS.Libraries.Enums.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Enum, AllowMultiple = false)]
    public class Description : System.ComponentModel.DescriptionAttribute
    {
        public Description(string value) : base(value)
        {
        }

        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof (DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            return value.ToString();
        }
    }
}
