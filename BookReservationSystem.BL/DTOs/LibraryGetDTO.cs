using BookReservationSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.BL.DTOs
{
    public class LibraryGetDTO
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
