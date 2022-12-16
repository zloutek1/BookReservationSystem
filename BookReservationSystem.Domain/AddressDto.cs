using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class AddressDto
{
    public Guid Id { get; set; }
    
    [Required]
    public string Country { get; set; } = null!;
    
    [Required]
    public string City { get; set; } = null!;
    
    [Required]
    public string PostalCode { get; set; } = null!;
    
    public string? Street { get; set; }
    
    public int StreetNumber { get; set; }
}