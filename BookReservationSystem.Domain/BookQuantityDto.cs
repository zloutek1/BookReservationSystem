namespace BookReservationSystem.Domain;

public class BookQuantityDto
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid LibraryId { get; set; }
    public int Count { get; set; }
}