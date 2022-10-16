using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReservationSystemDAL.Models
{
    public class BookQuantityRelation : BaseEntity
    {
        //idk ci treba este nejake ine properties okrem id alebo to inak spravit

        [ForeignKey(nameof(LibraryId))]
        public Guid LibraryId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Guid BookId { get; set; }

        public int Quantity { get; set; }
    }
}