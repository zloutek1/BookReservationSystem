using System.ComponentModel.DataAnnotations;
using BookReservationSystem.DAL.Models;

namespace BookReservationSystem.Domain;

public class ReviewDto
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    
    public DateTime Date { get; set; }
    
    public int Rating { get; set; }
    
    [Required]
    public BookShortDto Book { get; set; } = null!;
    
    [Required]
    public AuthorDto Author { get; set; } = null!;
}
