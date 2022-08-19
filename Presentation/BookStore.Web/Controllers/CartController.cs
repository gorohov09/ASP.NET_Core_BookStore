using BookStore.Domain.Interfaces;
using BookStore.Web.Extensions;
using BookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public CartController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Add(int id)
        {
            var book = _bookRepository.GetById(id);
            Cart cart;
            if (!HttpContext.Session.TryGetCart(out cart))
                cart = new Cart();

            if (cart.Items.ContainsKey(id))
                cart.Items[id]++;

            else
                cart.Items.Add(id, 1);
            cart.TotalSum += book.Price;

            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Book", new {id = book.Id});
        }
    }
}
