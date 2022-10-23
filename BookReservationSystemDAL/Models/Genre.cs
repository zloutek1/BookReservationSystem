using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookReservationSystemDAL.Models;

[Index(nameof(Name), IsUnique = true)]
public class Genre : BaseEntity
{
    [Required]
    public string Name { get; set; }

    public virtual List<Book> Books { get; set; } = new List<Book>();
}
