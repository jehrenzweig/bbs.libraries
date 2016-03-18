using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Enums.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = false)]
    public class Info : System.Attribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Abbreviation { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public string[] Categories { get; set; }
        public object[] Other { get; set; }

        public Info()
        {
            Active = true;
        }

        public static string GetAbbreviation(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (Info[]) fi.GetCustomAttributes(typeof (Info), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Abbreviation;
            return value.ToString();
        }

        public static string GetCode(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (Info[]) fi.GetCustomAttributes(typeof (Info), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Code;
            return value.ToString();
        }

        public static string GetValue(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (Info[]) fi.GetCustomAttributes(typeof (Info), false);
            if (attributes != null && attributes.Length > 0 && attributes.Any(attrb => !string.IsNullOrEmpty(attrb.Value)))
                return attributes[0].Value;
            return value.ToString();
        }

        public static string GetName(string abbreviation)
        {
            return string.Empty;
        }

        public static string GetName(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (Info[]) fi.GetCustomAttributes(typeof (Info), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Name;
            return value.ToString();
        }

        public static bool IsActive(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (Info[]) fi.GetCustomAttributes(typeof (Info), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Active;
            return false;
        }

        public static bool IsInCategory(Enum value, string category)
        {
            if (GetCategories(value).Contains(category))
            {
                return true;
            }
            return false;
        }

        public static List<string> GetCategories(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (Info[]) fi.GetCustomAttributes(typeof (Info), false);
            var categories = new List<string>();
            if (attributes != null && attributes.Length > 0 && attributes.Any(x => x.Categories != null))
            {
                for (int i = 0; i < attributes.Length; i++)
                {
                    categories.Add(attributes[i].Categories[0]);
                }
                return categories;
            }
            return null;
        }
    }
}