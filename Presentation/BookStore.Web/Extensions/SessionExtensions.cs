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
                writer.Write(value.OrderId);
                writer.Write(value.TotalCount);
                writer.Write(value.TotalPrice);

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
                    var orderId = reader.ReadInt32();
                    var totalCount = reader.ReadInt32();
                    var totalPrice = reader.ReadDecimal();

                    value = new Cart(orderId)
                    {
                        TotalCount = totalCount,
                        TotalPrice = totalPrice
                    };

                    return true;
                }
            }
            value = null;
            return false;
        }
    }
}
