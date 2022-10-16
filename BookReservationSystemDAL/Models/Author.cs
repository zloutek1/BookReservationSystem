using System.ComponentModel.DataAnnotations;

namespace BookReservationSystemDAL.Models;

public class Author : BaseEntity
{
    [Required]
    [MaxLength(64)]
    public string Name { get; set; }

    public virtual List<Book> Books { get; set; } = new List<Book>();
}
