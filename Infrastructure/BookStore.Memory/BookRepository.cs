using BookStore.Domain;
using System.Linq;

namespace BookStore.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] _books = new[]
        {
            new Book(1, "Art Of Programming"),
            new Book(2, "Refactoring"),
            new Book(3, "C Programming Language"),
        };

        public Book[] GetAllByTitle(string titlePart)
        {
            return _books.Where(book => book.Title.Contains(titlePart))
                .ToArray();
        }
    }
}
