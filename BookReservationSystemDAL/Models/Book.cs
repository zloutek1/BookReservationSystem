using System.ComponentModel.DataAnnotations;

namespace BookReservationSystemDAL.Models;

public class Book : BaseEntity
{
    [MaxLength(64)]
    public string Name { get; set; }

    [MaxLength(1000)]
    public string Abstract { get; set; }

    [MaxLength(256)]
    public string? CoverArtUrl { get; set; }

    public long ISBN { get; set; }

    public virtual List<Genre> Genres { get; set; } = new List<Genre>();

    public virtual List<Author> Authors { get; set; } = new List<Author>();

    public virtual List<Publisher> Publishers { get; set; } = new List<Publisher>();

    public virtual List<Review> Reviews { get; set; } = new List<Review>();
}