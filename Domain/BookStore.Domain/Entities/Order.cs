﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Order
    {
        public int Id { get; }

        private List<OrderItem> _items;
        public IReadOnlyCollection<OrderItem> Items
        {
            get { return _items; } //Неявное приведение List к IReadOnlyCollection
        }

        /// <summary>
        /// Общее колличество
        /// </summary>
        public int TotalCount => _items.Sum(o => o.Count);

        /// <summary>
        /// Общая цена
        /// </summary>
        public decimal TotalPrice => _items.Sum(o => o.Price * o.Count);

        public Order(int id, IEnumerable<OrderItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            Id = id;
            _items = new List<OrderItem>(items);
        }
    }
}
