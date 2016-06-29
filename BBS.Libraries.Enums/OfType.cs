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

namespace BBS.Libraries.Enums
{
    public partial class OfType<T>
    {
        public static T ParseAbbreviation(string abbreviation)
        {
            var enumValues = Validators.ValidateEnum<T>();

            foreach (var e in enumValues)
            {
                if (Attributes.Info.GetAbbreviation((Enum) e) == abbreviation)
                {
                    return (T) Enum.Parse(typeof (T), e.ToString());
                }
            }

            return default(T);
        }

        public static T ParseCode(string code)
        {
            var enumValues = Validators.ValidateEnum<T>();

            foreach (var e in enumValues)
            {
                if (Attributes.Info.GetCode((Enum) e) == code)
                {
                    return (T) Enum.Parse(typeof (T), e.ToString());
                }
            }

            return default(T);
        }

        public static T ParseName(string name)
        {
            var enumValues = Validators.ValidateEnum<T>();

            foreach (var e in enumValues)
            {
                if (Attributes.Info.GetName((Enum) e) == name)
                {
                    return (T) Enum.Parse(typeof (T), e.ToString());
                }
            }

            return default(T);
        }

        public static T ParseDescription(string description)
        {
            var enumValues = Validators.ValidateEnum<T>();

            foreach (var e in enumValues)
            {
                if (Attributes.Description.GetDescription((Enum) e) == description)
                {
                    return (T) Enum.Parse(typeof (T), e.ToString());
                }
            }

            return default(T);
        }

        public static T Parse(string value)
        {
            var enumValues = Validators.ValidateEnum<T>();

            foreach (var e in enumValues)
            {
                if (Attributes.Info.GetValue((Enum) e).Equals(value, StringComparison.InvariantCultureIgnoreCase))
                {
                    return (T) Enum.Parse(typeof (T), e.ToString());
                }
                if (Attributes.Info.GetAbbreviation((Enum) e) == value)
                {
                    return (T) Enum.Parse(typeof (T), e.ToString());
                }
                if (Attributes.Description.GetDescription((Enum) e) == value)
                {
                    return (T) Enum.Parse(typeof (T), e.ToString());
                }
                if (Attributes.Info.GetCode((Enum) e) == value)
                {
                    return (T) Enum.Parse(typeof (T), e.ToString());
                }
            }

            // Try getting by int value 

            int enumValue;
            if (int.TryParse(value, out enumValue))
            {
                return (T) Enum.ToObject(typeof (T), enumValue);
            }

            return default(T);
        }

        public static IEnumerable<T> ParseCategory(string category)
        {
            var result = new List<T>();

            var enumValues = Validators.ValidateEnum<T>();

            foreach (var e in enumValues)
            {
                if (Attributes.Info.GetCategories((Enum) e) != null && Attributes.Info.GetCategories((Enum) e).Contains(category))
                {
                    result.Add((T) Enum.Parse(typeof (T), e.ToString()));
                }
            }

            return result;
        }

        public static IEnumerable<T> ToList(bool active)
        {
            var result = new List<T>();

            var enumValueArray = Validators.ValidateEnum<T>();

            foreach (var value in enumValueArray)
            {
                if (active && Attributes.Info.IsActive(((Enum)value)))
                {
                    result.Add((T)Enum.Parse(typeof(T), value.ToString()));
                }
                else if (!active)
                {
                    result.Add((T)Enum.Parse(typeof(T), value.ToString()));
                }
            }

            return result;
        }

        public static IEnumerable<T> ToList()
        {
            return ToList(false);
        }
    }
}
