using BookReservationSystem.Domain;
using System.Collections.Generic;

namespace BookReservationSystem.MVC.Models
{
    public class BookFilterModel
    {
        public IEnumerable<BookDto> Books { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public long Isbn { get; set; }
        public bool SortByRating { get; set; }
        public bool OnlyAvailable { get; set; }
    }
}
