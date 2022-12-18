using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class ReservationDto
{
    public Guid Id { get; set; }

    [Required] 
    [DataType(DataType.Date)] 
    public DateTime ReservationDate { get; set; }

    [DataType(DataType.Date)] 
    public DateTime? DueDate { get; set; }

    [DataType(DataType.Date)] 
    public DateTime? PickupDate { get; set; }

    [DataType(DataType.Date)] 
    public DateTime? ReturnDate { get; set; }

    [Required]
    public LibraryShortDto Library { get; set; } = null!;
    
    [Required]
    public BookShortDto Book { get; set; } = null!;

    [Required]
    public UserShortDto User { get; set; } = null!;
}
