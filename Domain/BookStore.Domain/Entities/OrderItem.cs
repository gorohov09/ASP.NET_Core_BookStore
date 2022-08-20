using System;

namespace BookStore.Domain.Entities
{
    public class OrderItem
    {
        /// <summary>
        /// Id книги
        /// </summary>
        public int BookId { get; }

        /// <summary>
        /// Кол-во экземпляров книги
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Цена книги
        /// </summary>
        public decimal Price { get; } //Копия на время создания заказа

        public OrderItem(int bookId, int count, decimal price)
        {
            if (count <= 0)
                throw new ArgumentException("Count must be greater then zero");

            BookId = bookId;
            Count = count;
            Price = price;
        }
    }
}
