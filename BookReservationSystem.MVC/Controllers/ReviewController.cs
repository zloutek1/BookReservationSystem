using BookReservationSystem.BL.Exceptions;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BookReservationSystem.MVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IBookService _bookService;
        private IToastNotification _toastNotification;

        public ReviewController(IReviewService reviewService, IBookService bookService, IToastNotification toastNotification)
        {
            _reviewService = reviewService;
            _bookService = bookService;
            _toastNotification = toastNotification;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteFromBookDetail(Guid id)
        {
            var book = await _bookService.FindByReview(id);
            if (book == null)
            {
                _toastNotification.AddErrorToastMessage($"Review with id {id} not found");
                return RedirectToAction("Index", "Book");
            }

            try
            {
                await _reviewService.Delete(id);
            }
            catch (ServiceException ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
            }

            return RedirectToAction("Detail", "Book", new { id = book.Id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteFromProfile(Guid id)
        {
            try
            {
                await _reviewService.Delete(id);
            }
            catch (ServiceException ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
            }

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

            try
            {
                await _reviewService.Insert(createDto);
            }
            catch (ServiceException ex)
            {
                _toastNotification.AddErrorToastMessage(ex.Message);
            }

            return RedirectToAction("Index", "Book", new { id = createDto.BookId });
        }
    }
}
