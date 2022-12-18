using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class BookQuantityCreateDto
{
    [Required]
    [Display(Name = "Book")]
    public Guid BookId { get; set; }
    
    [Required]
    public Guid LibraryId { get; set; }
    
    public int Count { get; set; }
}