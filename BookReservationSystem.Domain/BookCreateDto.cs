using Microsoft.AspNetCore.Http;

namespace BookReservationSystem.Domain;

public class BookCreateDto
{
    public string Name { get; set; }
    public string Abstract { get; set; }
    public IFormFile CoverArt { get; set; }
    public long Isbn { get; set; }
}
