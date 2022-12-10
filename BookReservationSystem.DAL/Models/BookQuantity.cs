using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReservationSystem.DAL.Models;

public class BookQuantity: BaseEntity
{
    [Required]
    public Guid BookId { get; set; }
    
    [ForeignKey(nameof(BookId))]
    public virtual Book? Book { get; set; }

    [Required]
    public Guid LibraryId { get; set; }
    
    [ForeignKey(nameof(LibraryId))]
    public virtual Library? Library { get; set; }
    
    [Required]
    public int Count { get; set; }

    [Required]
    public int Available { get; set; }
}