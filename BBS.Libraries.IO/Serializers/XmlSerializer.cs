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
using System.Runtime.Serialization;
using System.Text;

namespace BBS.Libraries.IO.Serializers
{
    public partial class XmlSerializer<T> : Serializer<T> where T : class, new()
    {
        public string Serialize(object @object, List<Type> knownTypes)
        {
            var result = string.Empty;

            using (var stream = new System.IO.MemoryStream())
            {
                var serializer = new DataContractSerializer(typeof(T), knownTypes);
                serializer.WriteObject(stream, @object);
                stream.Position = 0;
                using (var reader = new System.IO.StreamReader(stream))
                {
                    result = string.Format("{0}", reader.ReadToEnd());
                }
            }

            return result;
        }

        public override string Serialize(object @object)
        {
            return Serialize(@object, null);
        }

        public override T Deserialize(string value)
        {
            return Deserialize(value, null);
        }

        public override T Deserialize(string value, List<Type> knownTypes)
        {
            var result = new T();

            byte[] byteArray = Encoding.UTF8.GetBytes(value);

            using (var stream = new System.IO.MemoryStream(byteArray))
            {
                var serializer = new DataContractSerializer(typeof(T), knownTypes);
                stream.Position = 0;
                result = serializer.ReadObject(stream) as T;
            }
            return result;
        }
    }
}
