using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReservationSystemDAL.Models;

public class Review : BaseEntity
{
    [MaxLength(500)]
    public string? Content { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int Rating { get; set; }

    public Guid? BookId { get; set; }

    [ForeignKey(nameof(BookId))]
    public virtual Book? Book { get; set; }

    public Guid? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User? Author { get; set; }
}