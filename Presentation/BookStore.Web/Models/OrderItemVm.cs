namespace BookStore.Web.Models
{
    public class OrderItemVm
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice => Price * Count;
    }
}
