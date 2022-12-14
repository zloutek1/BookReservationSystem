namespace BookReservationSystem.Domain;

public class BookQuantityDto
{
    public BookShortDto Book { get; set; }
    public LibraryDto Library { get; set; }
    public int Count { get; set; }
}