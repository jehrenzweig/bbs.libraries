using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBS.Libraries.Contracts;

namespace BBS.Libraries.IO
{
    public abstract class Serializer<T> where T : class, new()
    {
        public T DeserializeFile(string fileName, List<Type> knownTypes = null)
        {
            var fileAsString = System.IO.File.ReadAllText(fileName, Encoding.UTF8);
            return Deserialize(fileAsString, knownTypes);
        }

        public void Write(object @object, string fileName)
        {
            var stringToSave = Serialize(@object);
            System.IO.File.WriteAllText(fileName, stringToSave, Encoding.UTF8);
        }

        public abstract string Serialize(object @object);
        public abstract T Deserialize(string value);

        public abstract T Deserialize(string value, List<Type> knownTypes);
    }
}