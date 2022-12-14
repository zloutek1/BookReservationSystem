using BookReservationSystem.DAL.Models;

namespace BookReservationSystem.Domain;

public class ReviewDto
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    
    public DateTime Date { get; set; }
    
    public int Rating { get; set; }
    
    public BookDto Book { get; set; }
    
    public AuthorDto Author { get; set; }
}
