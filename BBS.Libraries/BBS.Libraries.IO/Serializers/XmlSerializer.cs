using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
