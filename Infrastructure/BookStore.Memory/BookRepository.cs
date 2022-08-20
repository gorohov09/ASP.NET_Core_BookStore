using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] _books = new[]
        {
            new Book(1, "ISBN 12312-31231", "D. Knuth", "Art Of Programming", 
                "Описание", 7.19m),
            new Book(2, "ISBN 12312-31231", "M. Fowler", "Refactoring",
                "Описание", 12.1m),
            new Book(3, "ISBN 12312-31231", "B. Kernighan", "C Programming Language",
                "Описание", 23.0m),
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return _books.Where(book => book.Isbn == isbn)
                .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return _books.Where(book => book.Author.Contains(query)
                                     || book.Title.Contains(query))
                                     .ToArray();
        }

        public Book GetById(int id)
        {
            return _books.FirstOrDefault(book => book.Id == id);
        }

        public Book[] GetAllByIds(IEnumerable<int> ids)
        {
            return _books.Where(book => ids.Contains(book.Id))
                .ToArray();
        }
    }
}
