using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Domain
{
    public class ReservationUserFilterDto
    {
        public int? RequestedPageNumber { get; set; }
        public int PageSize { get; set; }

        public DateTime ReservationDate { get; set; }

        public string Email { get; set; }
    }
}
