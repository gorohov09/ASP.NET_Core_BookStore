using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using System.Linq;

namespace BookStore.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] _books = new[]
        {
            new Book(1, "ISBN 12312-31231", "D. Knuth", "Art Of Programming"),
            new Book(2, "ISBN 12312-31231", "M. Fowler", "Refactoring"),
            new Book(3, "ISBN 12312-31231", "B. Kernighan", "C Programming Language"),
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            throw new System.NotImplementedException();
        }

        public Book[] GetAllByTitle(string titlePart)
        {
            return _books.Where(book => book.Title.Contains(titlePart))
                .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            throw new System.NotImplementedException();
        }
    }
}
