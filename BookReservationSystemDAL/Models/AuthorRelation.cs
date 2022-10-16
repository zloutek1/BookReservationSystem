using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReservationSystemDAL.Models
{
    public class AuthorRelation : BaseEntity
    {
        //idk ci treba este nejake ine properties okrem id

        [ForeignKey(nameof(AuthorId))]
        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Guid BookId { get; set; }
    }
}
