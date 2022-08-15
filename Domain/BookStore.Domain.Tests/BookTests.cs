using BookStore.Domain.Entities;
using Xunit;

namespace BookStore.Domain.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = Book.IsIsbn(null);
        }
    }
}
