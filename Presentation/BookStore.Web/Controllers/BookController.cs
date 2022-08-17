using BookStore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
                return NotFound();
            return View(book);
        }
    }
}
