using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystemDAL.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
