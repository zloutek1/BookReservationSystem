using BookReservationSystem.Domain;

namespace BookReservationSystem.MVC.Models
{
    public class ReviewModel
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public BookDto Book { get; set; }
    }
}
