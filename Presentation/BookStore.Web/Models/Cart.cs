using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Web.Models
{
    public class Cart
    {
        public IDictionary<int, int> Items { get; set; } = new Dictionary<int, int>();

        public decimal TotalSum { get; set; }

        public int TotalCount => Items.Sum(x => x.Value);
    }
}
