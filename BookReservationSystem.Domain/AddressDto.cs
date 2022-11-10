namespace BookReservationSystem.Domain;

public class AddressDto
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string? Street { get; set; }
    public int StreetNumber { get; set; }
}