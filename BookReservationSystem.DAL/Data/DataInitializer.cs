using Microsoft.EntityFrameworkCore;
using BookReservationSystem.DAL.Models;

namespace BookReservationSystem.DAL.Data;

public static class DataInitializer
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        #region genres
        var satire = new Genre  { Id = Guid.NewGuid(), Name = "Satire" };
        var beletry = new Genre{ Id = Guid.NewGuid(), Name = "Beletry" };
        var horor = new Genre { Id = Guid.NewGuid(), Name = "Horor" };
        var fantasy = new Genre { Id = Guid.NewGuid(), Name = "Fantasy" };
        var detective = new Genre { Id = Guid.NewGuid(), Name = "Detective" };
        var comic = new Genre { Id = Guid.NewGuid(), Name = "Comic" };
        modelBuilder.Entity<Genre>().HasData(satire, beletry, horor, fantasy, detective, comic);
        #endregion

        #region books
        var kockyBook = new Book
        {
            Id = Guid.NewGuid(),
            Name = "Moje kočky, cizí kočky a já",
            Abstract = "Co kočky cítí? Znají humor? Na co myslí? Jak mám svou kočku rozmazlovat a komunikovat s ní? A jsou naši pokojoví tygři jasnovidci? Těmto a mnoha dalším zajímavým otázkám se obšírně věnuje laskavá, vtipná i poučná kniha od milovníka koček, který se svými kočičími mazlíčky prožil třináct let a za tu dobu se jim naučil hodně rozumět. Nabízí čtenářům pár užitečných výchovných rad, ale jak sám poznamenává, nakonec budou stejně k ničemu, protože kočky si vždycky změní páníčka k obrazu svému, nikoli naopak.",
            CoverArtPath = "~/book_covers/kockybookcover.jpg",
            Isbn = 9788024282442
        };
        var pavoukBook = new Book
        {
            Id = Guid.NewGuid(),
            Name = "Pavouk",
            Abstract = "Joona Linna se znovu ocitá v ohrožení života a zachránit ho může jedině Saga Bauerová.",
            CoverArtPath = "~/book_covers/pavouk.jpg",
            Isbn = 9788027513765
        };
        var draculaBook = new Book
        {
            Id = Guid.NewGuid(),
            Name = "Dracula",
            Abstract = "",
            CoverArtPath = "~/book_covers/dracula.jpg",
            Isbn = 9780141199337
        };
        var shiningBook = new Book
        {
            Id = Guid.NewGuid(),
            Name = "Shining",
            Abstract = "peepo",
            CoverArtPath = "~/book_covers/the-shining.jpg",
            Isbn = 9788055138343
        };
        var hobbitBook = new Book
        {
            Id = Guid.NewGuid(),
            Name = "Hobbit",
            Abstract = "Toto je příběh o tom, kterak se Pytlík vydal za dobrodružstvím a shledal, že náhle dělá a říká naprosto neočekávané věci… Bilbo Pytlík je hobit, který se těší z pohodlnéh a skromného života a jen zřídkakdy putuje dále než do své spižírny ve Dně pytle. Jeho spokojené bytí je však narušeno, když se jednoho dne u jeho prahu objeví čaroděj Gandalf v doprovodu třinácti trpaslíků a vezmou ho s sebou na cestu \"tam a zase zpátky\". Mají v úmyslu uloupit poklad mocného Šmaka, velikého a velmi nebezpečného draka... ",
            CoverArtPath = "~/book_covers/hobbit.jpg",
            Isbn = 9788025707418
        };

        modelBuilder.Entity<Book>(b =>
        {
            b.HasData(kockyBook, pavoukBook, draculaBook, shiningBook, hobbitBook);
            b.HasMany(p => p.Genres).WithMany(p => p.Books)
                .UsingEntity(j => j.HasData(new { BooksId = kockyBook.Id, GenresId = satire.Id }, 
                new {BooksId = pavoukBook.Id, GenresId = beletry.Id},
                new {BooksId = draculaBook.Id, GenresId = horor.Id},
                new {BooksId = shiningBook.Id, GenresId = horor.Id},
                new {BooksId = hobbitBook.Id, GenresId = fantasy.Id}));
        });
        #endregion

        #region authors
        var hape = new Author { Id = Guid.NewGuid(), Name = "Kerkeling Hape" };
        var kepler = new Author { Id = Guid.NewGuid(), Name = "Lars Kepler" };
        var stoker = new Author { Id = Guid.NewGuid(), Name = "Bram Stoker" };
        var king = new Author { Id = Guid.NewGuid(), Name = "Stephen King" };
        var tolkien = new Author { Id = Guid.NewGuid(), Name = "John Tolkien" };

        modelBuilder.Entity<Author>(b =>
        {
            b.HasData(hape, kepler, stoker, king, tolkien);
            b.HasMany(p => p.Books).WithMany(p => p.Authors)
                .UsingEntity(j => j.HasData(
                    new { AuthorsId = hape.Id, BooksId = kockyBook.Id },
                    new {AuthorsId = kepler.Id, BooksId = pavoukBook.Id},
                    new {AuthorsId = stoker.Id, BooksId = draculaBook.Id}, 
                    new {AuthorsId = king.Id, BooksId = shiningBook.Id},
                    new {AuthorsId = tolkien.Id, BooksId = hobbitBook.Id}));
        });
        #endregion

        #region publishers
        var euromedia = new Publisher { Id = Guid.NewGuid(), Name = "EUROMEDIA GROUP, a.s." };
        var host = new Publisher { Id = Guid.NewGuid(), Name = "Host" };
        var argo = new Publisher { Id = Guid.NewGuid(), Name = "ARGO" };
        var ikar = new Publisher { Id = Guid.NewGuid(), Name = "Ikar" };

        modelBuilder.Entity<Publisher>(b =>
        {
            b.HasData(euromedia, host, argo, ikar);
            b.HasMany(p => p.Books).WithMany(p => p.Publishers)
                .UsingEntity(j => j.HasData(new { PublishersId = euromedia.Id, BooksId = kockyBook.Id },
                new {PublishersId = host.Id, BooksId = pavoukBook.Id},
                new {PublishersId = argo.Id, BooksId = draculaBook.Id},
                new {PublishersId = ikar.Id, BooksId = shiningBook.Id},
                new {PublishersId = argo.Id, BooksId = hobbitBook.Id}));
        });
        #endregion

        #region library
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
            Name = "Knihy Dobrovský",
            AddressId = jostova.Id,
        };
        modelBuilder.Entity<Library>().HasData(dobrovsky);

        var kockyLibBook = new BookQuantity{BookId = kockyBook.Id,LibraryId = dobrovsky.Id,Count = 1};
        var pavoukLibBook = new BookQuantity { BookId = pavoukBook.Id, LibraryId = dobrovsky.Id, Count = 1 };
        var draculaLibBook = new BookQuantity { BookId = draculaBook.Id, LibraryId = dobrovsky.Id, Count = 2 };
        var shiningLibBook = new BookQuantity { BookId = shiningBook.Id, LibraryId = dobrovsky.Id, Count = 2 };
        var hobbitLibBook = new BookQuantity { BookId = hobbitBook.Id, LibraryId = dobrovsky.Id, Count = 0 };
        modelBuilder.Entity<BookQuantity>().HasData(kockyLibBook, pavoukLibBook, draculaLibBook, shiningLibBook, hobbitLibBook);
        #endregion

        #region roles
        var userRole = new Role 
        {
            Id = Guid.NewGuid(),
            Name = "User",
            NormalizedName = "USER"
        };
        
        var adminRole = new Role 
        {
            Id = Guid.NewGuid(),
            Name = "Admin",
            NormalizedName = "ADMIN"
        };
        
        modelBuilder.Entity<Role>().HasData(userRole, adminRole);
        #endregion

        #region users

        var demoUser = new User
        {
            Id = Guid.NewGuid(),
            UserName = "demo",
            NormalizedUserName = "DEMO",
            FirstName = "demo",
            LastName = "demo",
            Email = "demo@gmail.com",
            NormalizedEmail = "DEMO@GMAIL.COM",
            SecurityStamp = Guid.NewGuid().ToString("D"),
            PasswordHash = "AQAAAAEAACcQAAAAEI56EuIXWNrKlnYOdNxWJx+bnMJ0WWTjpo3Mn3P7HPBGV78AQjb9BJomuebALvEIqQ=="
        };
        
        var monkman = new User
        {
            Id = Guid.NewGuid(),
            UserName = "monkman",
            FirstName = "Westbrook",
            LastName = "Monkman",
            Email = "wmonkman0@zdnet.com",
            PasswordHash = "RLreUYnARxnE"
        };
        
        var maxWorthy = new User
        {
            Id = Guid.NewGuid(),
            UserName = "maxworthy",
            FirstName = "Madelene",
            LastName = "Maxworthy",
            Email = "mmaxworthy1@ning.com",
            PasswordHash = "bo09BbrTa",
        };

        modelBuilder.Entity<User>(b =>
        {
            b.HasData(demoUser, monkman, maxWorthy);
        });
        #endregion

        #region reservations
        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            LibraryId = dobrovsky.Id,
            BookId = kockyBook.Id,
            CustomerId = maxWorthy.Id,
            ReservationDate = new DateTime(2022, 10, 1, 18, 40, 01),
            DueDate = new DateTime(2022, 12, 31, 23, 59, 59)
        };
        modelBuilder.Entity<Reservation>().HasData(reservation);
        #endregion
    }
}
