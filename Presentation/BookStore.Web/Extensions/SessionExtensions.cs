using BookStore.Web.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace BookStore.Web.Extensions
{
    public static class SessionExtensions
    {
        private const string _key = "Cart";

        public static void Set(this ISession session, Cart value)
        {
            if (value == null)
                return;
            
            //BinaryWriter - класс, который помогает записать что-то в набор байтов
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(value.Items.Count);

                foreach (var item in value.Items)
                {
                    writer.Write(item.Key);
                    writer.Write(item.Value);
                }

                writer.Write(value.TotalSum);

                session.Set(_key, stream.ToArray());
            }
        }

        public static bool TryGetCart(this ISession session, out Cart value)
        {
            if (session.TryGetValue(_key, out byte[] buffer))
            {
                using (var stream = new MemoryStream(buffer))
                using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    value = new Cart();

                    var length = reader.ReadInt32();
                    for (int i = 0; i < length; i++)
                    {
                        var bookId = reader.ReadInt32();
                        var count = reader.ReadInt32();

                        value.Items.Add(bookId, count);
                    }

                    value.TotalSum = reader.ReadDecimal();
                    return true;
                }
            }
            value = null;
            return false;
        }
    }
}
