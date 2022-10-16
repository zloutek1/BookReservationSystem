﻿using Microsoft.EntityFrameworkCore;
using BookReservationSystemDAL.Models;

namespace BookReservationSystemDAL.Data;

public static class DataInitializer
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var satire = new Genre
        {
            Id = Guid.NewGuid(),
            Name = "Satire"
        };
        modelBuilder.Entity<Genre>().HasData(satire);

        var book = new Book
        {
            Id = Guid.NewGuid(),
            Name = "Moje kočky, cizí kočky a já",
            Abstract = "Co kočky cítí? Znají humor? Na co myslí? Jak mám svou kočku rozmazlovat a komunikovat s ní? A jsou naši pokojoví tygři jasnovidci? Těmto a mnoha dalším zajímavým otázkám se obšírně věnuje laskavá, vtipná i poučná kniha od milovníka koček, který se svými kočičími mazlíčky prožil třináct let a za tu dobu se jim naučil hodně rozumět. Nabízí čtenářům pár užitečných výchovných rad, ale jak sám poznamenává, nakonec budou stejně k ničemu, protože kočky si vždycky změní páníčka k obrazu svému, nikoli naopak.",
            CoverArtUrl = "https://www.knihydobrovsky.cz/thumbs/book-detail-fancy-box/mod_eshop/produkty/m/moje-kocky-cizi-kocky-a-ja-9788024282442.jpg",
            ISBN = 9788024282442
        };
        modelBuilder.Entity<Book>(b =>
        {
            b.HasData(book);
            b.HasMany(p => p.Genres).WithMany(p => p.Books)
                .UsingEntity(j => j.HasData(new
                {
                    BooksId = book.Id, 
                    GenresId = satire.Id
                }));
        });

        var hape = new Author 
        {
            Id = Guid.NewGuid(),
            Name = "Kerkeling Hape" 
        };
        modelBuilder.Entity<Author>(b =>
        {
            b.HasData(hape);
            b.HasMany(p => p.Books).WithMany(p => p.Authors)
                .UsingEntity(j => j.HasData(new
                {
                    AuthorsId = hape.Id,
                    BooksId = book.Id
                }));
        });

        var euromedia = new Publisher
        {
            Id = Guid.NewGuid(),
            Name = "EUROMEDIA GROUP, a.s." 
        };
        modelBuilder.Entity<Publisher>(b =>
        {
            b.HasData(euromedia);
            b.HasMany(p => p.Books).WithMany(p => p.Publishers)
                .UsingEntity(j => j.HasData(new
                {
                    PublishersId = euromedia.Id,
                    BooksId = book.Id
                }));
        });

        var jostova = new Address
        {
            Id = Guid.NewGuid(),
            Country = "CZ",
            City = "Brno",
            PostalCode = " 60200",
            Street = "Joštová",
            StreetNumber = 6
        };
        modelBuilder.Entity<Address>().HasData(jostova);

        var dobrovsky = new Library
        {
            Id = Guid.NewGuid(),
            AddressId = jostova.Id,
        };
        modelBuilder.Entity<Library>().HasData(dobrovsky);

        var bookInLibrary = new BookQuantity
        {
            BookId = book.Id,
            LibraryId = dobrovsky.Id,
            Count = 1
        };
        modelBuilder.Entity<BookQuantity>().HasData(bookInLibrary);

        var admin = new Role 
        {
            Id = Guid.NewGuid(),
            Name = "admin" 
        };
        modelBuilder.Entity<Role>().HasData(admin);

        var monkman = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "Westbrook",
            LastName = "Monkman",
            Email = "wmonkman0@zdnet.com",
            Password = "RLreUYnARxnE",
            PasswordSalt = ""
        };
        modelBuilder.Entity<User>().HasData(monkman);

        var maxworthy = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "Madelene",
            LastName = "Maxworthy",
            Email = "mmaxworthy1@ning.com",
            Password = "bo09BbrTa",
            PasswordSalt = ""
        };
        modelBuilder.Entity<User>().HasData(maxworthy);

        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            LibraryId = dobrovsky.Id,
            BookId = book.Id,
            CustomerId = maxworthy.Id,
            ReservationDate = new DateTime(2022, 10, 1, 18, 40, 01),
            DueDate = new DateTime(2022, 12, 31, 23, 59, 59)
        };
        modelBuilder.Entity<Reservation>().HasData(reservation);

    }
}