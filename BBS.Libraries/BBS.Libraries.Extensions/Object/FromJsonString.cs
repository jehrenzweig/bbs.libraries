using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BBS.Libraries.Extensions
{
    public static partial class Object
    {
        public static T FromJsonString<T>(this string jsonString) where T : class, new()
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };

            return JsonConvert.DeserializeObject<T>(jsonString, settings);
        }
    }
}
