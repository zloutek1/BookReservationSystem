using BookReservationSystem.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookReservationSystem.MVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<IActionResult> DeleteReview(Guid reviewId)
        {
            await _reviewService.Delete(reviewId);
            return RedirectToAction("Profile", "User");
        }
    }
}
