using System.ComponentModel.DataAnnotations;

namespace BookReservationSystemDAL.Models;

public class Genre : BaseEntity
{
    [Required]
    public string Name { get; set; }

    public virtual List<Book> Books { get; set; } = new List<Book>();
}