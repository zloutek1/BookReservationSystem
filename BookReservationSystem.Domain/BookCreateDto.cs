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
    
    [Display(Name = "Genres")]
    public List<Guid> GenreIds { get; set; } = new();
    
    [Display(Name = "Authors")]
    public List<Guid> AuthorIds { get; set; } = new();
    
    [Display(Name = "Publishers")]
    public List<Guid> PublisherIds { get; set; } = new();
}
