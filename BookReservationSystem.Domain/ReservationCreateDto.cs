using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class ReservationCreateDto
{
    [Required]
    [DataType(DataType.Date)]
    public DateTime ReservationDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }

    [Required]
    [Display(Name="Library")]
    public Guid LibraryId { get; set; }
    
    [Required]
    public Guid BookId { get; set; }
    
    [Required]
    public string UserName { get; set; } = null!;
}
