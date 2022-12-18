using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class LibraryShortDto
{
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
    
    [Required]
    public AddressDto Address { get; set; } = null!;
}
