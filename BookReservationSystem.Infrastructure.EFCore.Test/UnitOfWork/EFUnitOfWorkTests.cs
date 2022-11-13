using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BookReservationSystem.Infrastructure.EFCore.Test.UnitOfWork;

public class EFUnitOfWorkTests : IDisposable
{
    private readonly DatabaseFixture _databaseFixture = new();
    
    [Fact]
    public async void LibraryRepository_WithPositiveBookCount_Saves()
    {
        var addressId = Guid.NewGuid();
        var libraryId = Guid.NewGuid();
        var bookId = Guid.NewGuid();

        await using (var context = _databaseFixture.CreateContext())
        {
            using (var bookUow = new BookUnitOfWork(context))
            {
                bookUow.BookRepository.Insert(new Book
                {
                    Id = bookId,
                    Abstract = "",
                    Isbn = 123456789L,
                    CoverArtPath = "../Resources/example.jpg",
                    Name = "BooName"
                });
                await bookUow.Commit();
            }

            using (var libraryUow = new LibraryUnitOfWork(context))
            {
                var address = new Address
                {
                    Id = addressId,
                    City = "A",
                    Country = "B",
                    PostalCode = "C",
                    Street = "D",
                    StreetNumber = 1
                };
                libraryUow.AddressRepository.Insert(address);

                var library = new Library
                {
                    Id = libraryId,
                    Name = "Dobrovsky",
                    AddressId = addressId,
                    Books = new List<BookQuantity> { new() { BookId = bookId, LibraryId = libraryId, Count = 4 } }
                };
                libraryUow.LibraryRepository.Insert(library);
                var x = libraryUow.LibraryRepository.FindById(libraryId);
                await libraryUow.Commit();
            }
        }

        Library? foundLibrary;
        await using (var context = _databaseFixture.CreateContext())
        {
            using var libraryUow = new LibraryUnitOfWork(context);
            foundLibrary = libraryUow.LibraryRepository.FindById(libraryId);
            
            Assert.NotNull(foundLibrary);
            await context.Entry(foundLibrary!).Collection("Books").LoadAsync();
        }
        
        Assert.Single(foundLibrary!.Books);
    }
    
    [Fact]
    public async void GenreRepository_SameName_Throws()
    {
        await using var context = _databaseFixture.CreateContext();
        using var unitOfWork = new GenreUnitOfWork(context);

        unitOfWork.GenreRepository.Insert(new Genre { Id = Guid.NewGuid(), Name = "Horror" });
        unitOfWork.GenreRepository.Insert(new Genre { Id = Guid.NewGuid(), Name = "Horror" });
            
        await Assert.ThrowsAsync<DbUpdateException>(async () => await unitOfWork.Commit());
    }
    
    public void Dispose()
    {
        _databaseFixture.Dispose();
    }
}