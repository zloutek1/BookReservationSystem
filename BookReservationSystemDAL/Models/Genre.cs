namespace BookReservationSystemDAL.Models;

public class Genre : BaseEntity
{
    public string Name { get; set; }

    public virtual List<Book> Books { get; set; } = new List<Book>();
}