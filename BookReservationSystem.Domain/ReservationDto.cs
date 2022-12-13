namespace BookReservationSystem.Domain;

public class ReservationDto
{
    public Guid Id { get; set; }
    public DateTime ReservationDate { get; set; }

    public DateTime? DueDate { get; set; }
    public DateTime? PickupDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public LibraryDto Library { get; set; }
    public BookDto Book { get; set; }
    public Guid CustomerId { get; set; }
}
