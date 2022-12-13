using BookReservationSystem.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookReservationSystem.MVC.Controllers
{
    public class ReviewController : Controller
    {
        private IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public IActionResult DeleteReview(Guid reviewId)
        {
            _reviewService.Delete(reviewId);
            return RedirectToAction("Profile", "User");
        }
    }
}
