﻿using BookStore.Domain.Entities;
using System;
using Xunit;

namespace BookStore.Domain.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WithNullItems_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(1, null));
        }

        [Fact]
        public void TotalCount_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(1, new OrderItem[0]);

            Assert.Equal(0, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(1, new OrderItem[0]);

            Assert.Equal(0m, order.TotalPrice);
        }

        [Fact]
        public void TotalCount_WithNonEmptyItems_CalculateTotalCountAndPrice()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(1, 5, 100m),
            });

            Assert.Equal(3 + 5, order.TotalCount);
            Assert.Equal(3 * 10m + 5 * 100m, order.TotalPrice);
        }
    }
}
