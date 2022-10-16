﻿using System.ComponentModel.DataAnnotations;

namespace BookReservationSystemDAL.Models;

public class Book : BaseEntity
{
    [Required]
    [MaxLength(64)]
    public string Name { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Abstract { get; set; }

    [Required]
    [MaxLength(256)]
    public string? CoverArtUrl { get; set; }

    [Required]
    public long ISBN { get; set; }

    public virtual List<Genre> Genres { get; set; } = new List<Genre>();

    public virtual List<Author> Authors { get; set; } = new List<Author>();

    public virtual List<Publisher> Publishers { get; set; } = new List<Publisher>();

    public virtual List<Review> Reviews { get; set; } = new List<Review>();
}