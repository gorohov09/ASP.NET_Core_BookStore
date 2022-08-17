using System.Collections;
using System.Collections.Generic;

namespace BookStore.Web.Models
{
    public class Cart
    {
        public IDictionary<int, int> Items { get; set; } = new Dictionary<int, int>();

        public decimal TotalSum { get; set; }
    }
}
