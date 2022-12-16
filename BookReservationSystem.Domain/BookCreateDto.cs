using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BookReservationSystem.Domain;

public class BookCreateDto
{
    [Required]
    public string Name { get; set; } = null!;
    
    [Required]
    public string Abstract { get; set; } = null!;
    
    public IFormFile? CoverArt { get; set; }
    
    [Required]
    public long Isbn { get; set; }
}
