using BookReservationSystem.Domain;

namespace BookReservationSystem.MVC.Models
{
    public class BookReviewViewModel
    {
        public IEnumerable<ReviewDto> Reviews { get; set; }
    }
}
