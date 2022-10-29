using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.DAL.Models;

public class Publisher : BaseEntity
{
    [Required]
    [MaxLength(64)]
    public string Name { get; set; }

    public virtual List<Book> Books { get; set; } = new List<Book>();
}
