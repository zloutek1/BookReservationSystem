using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.DAL.Models;

public class Book : BaseEntity
{
    [Required]
    [MaxLength(64)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(1000)]
    public string Abstract { get; set; } = null!;

    [MaxLength(256)]
    public string? CoverArtPath { get; set; }

    [Required]
    public long Isbn { get; set; }

    public virtual List<Genre> Genres { get; set; } = new();

    public virtual List<Author> Authors { get; set; } = new();

    public virtual List<Publisher> Publishers { get; set; } = new();

    public virtual List<Review> Reviews { get; set; } = new();

    public virtual List<BookQuantity> BookQuantities { get; set; } = new();
    
    public float AverageRating { get; set; }
}
