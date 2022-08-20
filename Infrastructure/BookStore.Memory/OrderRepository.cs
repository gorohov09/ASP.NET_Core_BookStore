using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Memory
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();
        public Order Create()
        {
            var nextId = _orders.Count + 1;
            var order = new Order(nextId, new OrderItem[0]);

            _orders.Add(order);

            return order;
        }

        public Order GetById(int id)
        {
            return _orders.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Order order)
        {
            ;
        }
    }
}
