using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookReservationSystemDAL.Models;

public class Genre : BaseEntity
{
    [Required]
    public string Name { get; set; }

    public virtual List<Book> Books { get; set; } = new List<Book>();
}
