using BookStore.Domain.Entities;
using System;
using Xunit;

namespace BookStore.Domain.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                int count = 0;
                new OrderItem(1, count, 0m);
            });
        }

        [Fact]
        public void OrderItem_WithNegativeCount_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                int count = -7;
                new OrderItem(1, count, 0m);
            });
        }

        [Fact]
        public void OrderItem_WithPositiveCount_ThrowsArgumentException()
        {
            var order = new OrderItem(1, 2, 3m);

            Assert.Equal(1, order.BookId);
            Assert.Equal(2, order.Count);
            Assert.Equal(3m, order.Price);
        }
    }
}
