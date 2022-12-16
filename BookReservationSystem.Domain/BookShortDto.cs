using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class BookShortDto
{
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
    
    [Required]
    public string Abstract { get; set; } = null!;
    
    public string? CoverArtPath { get; set; }
    
    public long Isbn { get; set; }
}
