using BookStore.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly BookService _bookService;

        public SearchController(BookService bookRepository)
        {
            _bookService = bookRepository;
        }

        public IActionResult Index(string query)
        {
            var books = _bookService.GetAllByQuery(query);
            return View(books);
        }
    }
}
