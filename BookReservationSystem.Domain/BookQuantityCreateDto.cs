using System.ComponentModel.DataAnnotations;
using BookReservationSystem.Domain.Validators;

namespace BookReservationSystem.Domain;

public class BookQuantityCreateDto
{
    [Required]
    [Display(Name = "Book")]
    public Guid BookId { get; set; }
    
    [Required]
    public Guid LibraryId { get; set; }
    
    [NotNegative]
    public int Count { get; set; }
}