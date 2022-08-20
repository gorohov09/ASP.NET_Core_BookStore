using System.Collections.Generic;

namespace BookStore.Web.Models
{
    public class OrderVm
    {
        public int Id { get; set; }

        public List<OrderItemVm> Items = new List<OrderItemVm>();

        public int TotalCount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
