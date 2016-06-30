//-----------------------------------------------------------------------
//    MIT License
//
//    Copyright (c) Wednesday, June 29, 2016 1:15:39 PM Betabyte Software
//
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the "Software"), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:
//
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.

//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//    SOFTWARE.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

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
            var attribute = Helpers.GetAttributes<Info>(value).FirstOrDefault();

            if (attribute != null)
                return attribute.Abbreviation;
            return value.ToString();
        }

        public static string GetCode(Enum value)
        {
            var attribute = Helpers.GetAttributes<Info>(value).FirstOrDefault();

            if (attribute != null)
                return attribute.Code;
            return value.ToString();
        }

        public static string GetValue(Enum value)
        {
            var attribute = Helpers.GetAttributes<Info>(value).FirstOrDefault();

            if (attribute != null && !string.IsNullOrEmpty(attribute.Value))
                return attribute.Value;

            return value.ToString();
        }

        public static string GetName(string abbreviation)
        {
            return string.Empty;
        }

        public static string GetName(Enum value)
        {
            var attribute = Helpers.GetAttributes<Info>(value).FirstOrDefault();

            if (attribute != null)
                return attribute.Name;
            return value.ToString();
        }

        public static bool IsActive(Enum value)
        {
            var attribute = Helpers.GetAttributes<Info>(value).FirstOrDefault();

            if (attribute != null)
                return attribute.Active;
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
            var attributes = Helpers.GetAttributes<Info>(value);

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
