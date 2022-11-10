namespace BookReservationSystem.Domain;

public class ReservationDto
{
    public Guid Id { get; set; }
    public DateTime ReservationDate { get; set; }

    public DateTime? DueDate { get; set; }
    public DateTime? PickupDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public Guid LibraryId { get; set; }
    public Guid BookId { get; set; }
    public Guid CustomerId { get; set; }
}
