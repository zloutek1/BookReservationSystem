﻿using System.ComponentModel.DataAnnotations;

namespace BookReservationSystem.Domain;

public class BookQuantityDto
{
    [Required]
    public BookShortDto Book { get; set; } = null!;
    
    [Required]
    public LibraryDto Library { get; set; } = null!;
    
    public int Count { get; set; }
}