using System.ComponentModel.DataAnnotations;
using BookReservationSystem.Domain.Validators;

namespace BookReservationSystem.Domain;

public class BookQuantityDto
{
    [Required]
    public BookShortDto Book { get; set; } = null!;
    
    [Required]
    public LibraryShortDto Library { get; set; } = null!;
    
    [NotNegative]
    public int Count { get; set; }
}