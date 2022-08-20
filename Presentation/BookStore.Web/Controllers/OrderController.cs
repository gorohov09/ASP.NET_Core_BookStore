using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using BookStore.Web.Extensions;
using BookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            _bookRepository = bookRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart)) //Если корзина существует, отображаем ее
            {
                var order = _orderRepository.GetById(cart.OrderId);

                var model = new OrderVm
                {
                    Id = order.Id,
                    TotalCount = order.TotalCount,
                    TotalPrice = order.TotalPrice,
                };

                foreach (var orderItem in order.Items)
                {
                    var book = _bookRepository.GetById(orderItem.BookId);
                    model.Items.Add(new OrderItemVm
                    {
                        BookId = orderItem.BookId,
                        Price = orderItem.Price,
                        Count = orderItem.Count,
                        Author = book.Author,
                        Title = book.Title,
                    });
                }

                return View(model);
            }

            return View("Empty");
        }

        public IActionResult AddItem(int id)
        {
            Order order;
            Cart cart;

            if (HttpContext.Session.TryGetCart(out cart))
                order = _orderRepository.GetById(cart.OrderId);
            else
            {
                order = _orderRepository.Create();
                cart = new Cart(order.Id);
            }

            var book = _bookRepository.GetById(id);
            order.AddItem(book, 1);
            _orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;

            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Book", new {id = book.Id});
        }
    }
}
