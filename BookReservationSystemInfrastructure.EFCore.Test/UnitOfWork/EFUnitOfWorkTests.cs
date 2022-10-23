using BookReservationSystemDAL.Data;
using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.EFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BookReservationSystemInfrastructure.EFCore.Test.UnitOfWork;

public class EFUnitOfWorkTests : IDisposable
{
    private readonly DatabaseFixture _databaseFixture = new DatabaseFixture();
    
    [Fact]
    public async void LibraryRepository_WithPositiveBookCount_Saves()
    {
        Library? foundLibrary;
        await using (var context = _databaseFixture.CreateContext())
        {
            var unitOfWork = new EFUnitOfWork(context);

            var bookId = Guid.NewGuid();
            unitOfWork.BookRepository.Insert(new Book
            {
                Id = bookId,
                Abstract = "",
                Isbn = 123456789L,
                CoverArtUrl = "http://example.com",
                Name = "BooName"
            });

            var addressId = Guid.NewGuid();
            unitOfWork.AddressRepository.Insert(new Address
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
            unitOfWork.LibraryRepository.Insert(library);

            await unitOfWork.Commit();

            foundLibrary = unitOfWork.LibraryRepository.GetById(libraryId);
        }

        Assert.Equal(1, foundLibrary?.Books.Count);
    }
    
    [Fact]
    public async void GenreRepository_SameName_Throws()
    {
        Genre? current;
        await using (var context = _databaseFixture.CreateContext())
        {
            var unitOfWork = new EFUnitOfWork(context);

            var id = Guid.NewGuid();
            unitOfWork.GenreRepository.Insert(new Genre { Id = id, Name = "Horror" });
            unitOfWork.GenreRepository.Insert(new Genre { Id = Guid.NewGuid(), Name = "Horror" });
            
            await Assert.ThrowsAsync<DbUpdateException>( async () => await unitOfWork.Commit());

        }
    }
    
    public void Dispose()
    {
        _databaseFixture.Dispose();
    }
}