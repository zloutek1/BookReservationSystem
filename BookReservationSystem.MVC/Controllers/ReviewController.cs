using BookReservationSystem.BL.IServices;
using BookReservationSystem.BL.Services;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookReservationSystem.MVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IBookService _bookService;

        public ReviewController(IReviewService reviewService, IBookService bookService)
        {
            _reviewService = reviewService;
            _bookService = bookService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteFromBookDetail(ReviewDto reviewDto)
        {
            var book = reviewDto.Book;

            await _reviewService.Delete(reviewDto.Id);
            return book == null ? View("Error") : View("../Book/BookDetail", book);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteFromProfile(Guid id)
        {
            await _reviewService.Delete(id);
            return RedirectToAction("Profile", "User");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> IndexForBook(Guid bookId)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            var reviews = await _reviewService.FindAllForBook(bookId);
            return View(reviews);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> IndexForUser(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            var reviews = await _reviewService.FindAllFromUser(userId);
            return View(reviews);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index(Guid id)
        {
            var review = new ReviewCreateDto
            {
                BookId = id,
                UserName = User.Identity?.Name!
            };
            return View(review);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(ReviewCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createDto);
            }

            await _reviewService.Insert(createDto);

            var book = await _bookService.FindById(createDto.BookId);
            return book == null ? View("Error") : View("../Book/BookDetail", book);
        }
    }
}
