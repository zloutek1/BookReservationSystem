using System.ComponentModel.DataAnnotations.Schema;

namespace BookReservationSystemDAL.Models;

public class BooksInLibrary: BaseEntity
{
    public Guid BookId { get; set; }
    
    [ForeignKey(nameof(BookId))]
    public virtual Book Book { get; set; }

    public Guid LibraryId { get; set; }
    
    [ForeignKey(nameof(LibraryId))]
    public virtual Library Library { get; set; }
    
    public int Count { get; set; }
}