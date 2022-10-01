using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemDAL.Models
{
    public class Author : BaseEntity
    {
        [MaxLength(64)]
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
