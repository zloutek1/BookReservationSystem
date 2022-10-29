using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BookReservationSystem.Infrastructure.EFCore.Test.UnitOfWork;

public class EFUnitOfWorkTests : IDisposable
{
    private readonly DatabaseFixture _databaseFixture = new DatabaseFixture();
    
    [Fact]
    public async void LibraryRepository_WithPositiveBookCount_Saves()
    {
        Library? foundLibrary;
        await using (var context = _databaseFixture.CreateContext())
        {
            var bookUow = new BookUOW(context);
            var bookId = Guid.NewGuid();
            bookUow.BookRepository.Insert(new Book
            {
                Id = bookId,
                Abstract = "",
                Isbn = 123456789L,
                CoverArtPath = "../Resources/example.jpg",
                Name = "BooName"
            });
            await bookUow.Commit();

            var libraryUow = new LibraryUOW(context);
            var addressId = Guid.NewGuid();
            libraryUow.AddressRepository.Insert(new Address
            {
                Id = addressId,
                City = "A",
                Country = "B",
                PostalCode = "C",
                Street = "D",
                StreetNumber = 1
            });

            var libraryId = Guid.NewGuid();
            var library = new Library
            {
                Id = libraryId,
                Name = "Dobrovsky",
                AddressId = addressId,
                Books = new List<BookQuantity> { new() { BookId = bookId, LibraryId = libraryId, Count = 4 } }
            };
            libraryUow.LibraryRepository.Insert(library);
            await libraryUow.Commit();

            foundLibrary = libraryUow.LibraryRepository.GetById(libraryId);
        }

        Assert.Equal(1, foundLibrary?.Books.Count);
    }
    
    [Fact]
    public async void GenreRepository_SameName_Throws()
    {
        await using var context = _databaseFixture.CreateContext();
        var unitOfWork = new GenreUOW(context);

        var id = Guid.NewGuid();
        unitOfWork.GenreRepository.Insert(new Genre { Id = id, Name = "Horror" });
        unitOfWork.GenreRepository.Insert(new Genre { Id = Guid.NewGuid(), Name = "Horror" });
            
        await Assert.ThrowsAsync<DbUpdateException>( async () => await unitOfWork.Commit());
    }
    
    public void Dispose()
    {
        _databaseFixture.Dispose();
    }
}