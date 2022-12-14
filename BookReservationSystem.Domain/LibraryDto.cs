namespace BookReservationSystem.Domain;

public class LibraryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public AddressDto Address { get; set; }
}
