using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReservationSystem.DAL.Models;

public class Review : BaseEntity
{
    
    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int Rating { get; set; }
    
    [MaxLength(500)]
    public string Content { get; set; } = null!;

    [Required]
    public Guid BookId { get; set; }

    [ForeignKey(nameof(BookId))]
    public virtual Book? Book { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User? Author { get; set; }
}
