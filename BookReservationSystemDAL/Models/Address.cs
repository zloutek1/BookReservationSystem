using System.ComponentModel.DataAnnotations;

namespace BookReservationSystemDAL.Models;

public class Address : BaseEntity
{
    [MaxLength(64)]
    public string Country { get; set; }

    [MaxLength(64)]
    public string City { get; set; }

    [MaxLength(16)]
    public string PostalCode { get; set; }

    [MaxLength(64)]
    public string Street { get; set; }

    public int StreetNumber { get; set; }
}
