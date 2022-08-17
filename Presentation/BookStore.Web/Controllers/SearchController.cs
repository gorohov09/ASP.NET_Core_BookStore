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

        //search/index?query=title
        //IActionResult - готовая страница, набор заголовков(редирект), статусный код
        public IActionResult Index(string query)
        {
            if (query == null)
                return NotFound();
            var books = _bookService.GetAllByQuery(query);
            return View("Index", books); //Вызвали представление на прямую
        }
    }
}
