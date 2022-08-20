using BookStore.Domain.Entities;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces
{
    public interface IBookRepository
    {
        Book[] GetAllByIsbn(string isbn);

        Book[] GetAllByTitleOrAuthor(string titleOrAuthor);

        Book GetById(int id);

        Book[] GetAllByIds(IEnumerable<int> ids);
    }
}
