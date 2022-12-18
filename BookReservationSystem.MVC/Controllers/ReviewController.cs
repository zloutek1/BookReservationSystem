using BookReservationSystem.BL.IServices;
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteFromBookDetail(Guid id)
        {
            var book = await _bookService.FindByReview(id);

            await _reviewService.Delete(id);
            return book == null ? View("Error") : RedirectToAction("Detail", "Book", new { id = book.Id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteFromProfile(Guid id)
        {
            await _reviewService.Delete(id);
            return RedirectToAction("Profile", "User");
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
