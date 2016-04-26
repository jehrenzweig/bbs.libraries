using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Extensions
{
  public static partial class Object
  {
    public static string ToBase64String(this object @object)
    {
      if (@object != null)
      {
        using (var stream = new System.IO.MemoryStream())
        {
          new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize(stream, @object);

          return Convert.ToBase64String(stream.ToArray());
        }
      }
      return null;
    }

    public static object FromString(this string objectString) 
    {
      byte[] bytes = Convert.FromBase64String(objectString);
      using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes, 0, bytes.Length))
      {
        ms.Write(bytes, 0, bytes.Length);
        ms.Position = 0;
        return new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Deserialize(ms);
      }
    }
  }
}
