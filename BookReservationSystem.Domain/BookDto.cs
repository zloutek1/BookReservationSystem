namespace BookReservationSystem.Domain;

public class BookDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Abstract { get; set; }
    public string? CoverArtPath { get; set; }
    public long Isbn { get; set; }
}
