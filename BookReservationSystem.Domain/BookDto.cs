namespace BookReservationSystem.Domain;

public class BookDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Abstract { get; set; }
    public string? CoverArtPath { get; set; }
    public long Isbn { get; set; }
    
    public IEnumerable<GenreDto> Genres { get; set; }
    public IEnumerable<AuthorDto> Authors { get; set; }
    public IEnumerable<PublisherDto> Publishers { get; set; }
    public IEnumerable<ReviewDto> Reviews { get; set; }
    
    public IEnumerable<BookQuantityDto> BookQuantities { get; set; }
}
