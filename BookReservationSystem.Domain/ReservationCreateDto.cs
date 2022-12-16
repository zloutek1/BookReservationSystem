using System.ComponentModel.DataAnnotations;
using BookReservationSystem.Domain.Validators;

namespace BookReservationSystem.Domain;

public class ReservationCreateDto
{
    [Required]
    [DataType(DataType.DateTime)]
    [FutureOrPresent]
    public DateTime ReservationDate { get; set; }

    [Required]
    [FutureOrPresent]
    [DataType(DataType.DateTime)]
    [After(nameof(ReservationDate))]
    public DateTime DueDate { get; set; }

    [Required]
    [Display(Name="Library")]
    public Guid LibraryId { get; set; }
    
    [Required]
    public Guid BookId { get; set; }
    
    [Required]
    public string UserName { get; set; } = null!;
}
