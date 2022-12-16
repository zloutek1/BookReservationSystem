using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.DAL.Models;

public class Address : BaseEntity
{
    [Required]
    [MaxLength(64)]
    public string Country { get; set; } = null!;

    [Required]
    [MaxLength(64)]
    public string City { get; set; } = null!;

    [Required]
    [MaxLength(16)]
    public string PostalCode { get; set; } = null!;

    [MaxLength(64)]
    public string? Street { get; set; }

    [Required]
    public int StreetNumber { get; set; }
}