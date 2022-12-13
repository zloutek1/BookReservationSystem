using BookReservationSystem.BL.IServices;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReservationSystem.MVC.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("SearchBooks")]
        public IActionResult SearchBooks(BookFilterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("SearchBooks");
            }
            model.Books = _bookService.FilterBooks(model.Name, model.Author, model.Isbn, model.Publisher, model.Genre, model.SortByRating, model.OnlyAvailable);
            return View("SearchBooks", model);
        }
    }
}
