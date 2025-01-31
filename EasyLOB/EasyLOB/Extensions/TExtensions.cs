using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace EasyLOB
{
    public static class TExtensions
    {
        public static T CloneDeep<T>(this T o)
        {
            if (Object.ReferenceEquals(o, null))
            {
                return default(T);
            }

            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, o);
                stream.Position = 0;

                return (T)formatter.Deserialize(stream);
            }
        }

        public static bool In<T>(this T item, params T[] items)
        {
            // int i = 1;
            // bool in = i.In(1, 2, 3);

            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.Contains(item);
        }
    }
}
