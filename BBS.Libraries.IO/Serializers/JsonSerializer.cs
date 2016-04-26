using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBS.Libraries.Extensions;

namespace BBS.Libraries.IO.Serializers
{
    public partial class JsonSerializer<T> : Serializer<T> where T : class, new()
    {
        public override string Serialize(object @object)
        {
            throw new NotImplementedException("Please use extensions");
        }

        public override T Deserialize(string value, List<Type> knownTypes)
        {
            throw new NotImplementedException();
        }

        public override T Deserialize(string value)
        {
            return value.FromJsonString<T>();
        }
    }
}