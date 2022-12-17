using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class BookDto
{
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
    
    [Required]
    public string Abstract { get; set; } = null!;
    
    public string? CoverArtPath { get; set; }
    
    public long Isbn { get; set; }

    public float Rating { get; set; }
    
    
    public IEnumerable<GenreDto> Genres { get; set; } = null!;
    public IEnumerable<AuthorDto> Authors { get; set; } = null!;
    public IEnumerable<PublisherDto> Publishers { get; set; } = null!;
    public IEnumerable<ReviewDto> Reviews { get; set; } = null!;
    public IEnumerable<BookQuantityDto> BookQuantities { get; set; } = null!;
}
