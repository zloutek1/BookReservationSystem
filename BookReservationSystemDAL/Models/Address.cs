using System.ComponentModel.DataAnnotations;

namespace BookReservationSystemDAL.Models;

public class Address : BaseEntity
{
    [Required]
    [MaxLength(64)]
    public string Country { get; set; }

    [Required]
    [MaxLength(64)]
    public string City { get; set; }

    [Required]
    [MaxLength(16)]
    public string PostalCode { get; set; }

    [Required]
    [MaxLength(64)]
    public string Street { get; set; }

    [Required]
    public int StreetNumber { get; set; }
}
