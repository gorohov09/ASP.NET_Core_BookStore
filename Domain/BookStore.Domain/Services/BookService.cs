using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    /// <summary>
    /// Служба доменной области(сервис)
    /// </summary>
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book[] GetAllByQuery(string query)
        {
            if (Book.IsIsbn(query))
                return _bookRepository.GetAllByIsbn(query);

            return _bookRepository.GetAllByTitleOrAuthor(query);
        }
    }
}
