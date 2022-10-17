using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.EFCore.UnitOfWork;

namespace BookReservationSystemInfrastructure.EFCore.Test.UnitOfWork;

public class EFUnitOfWorkTests : TestConfig
{

    [Fact]
    public async void LibraryRepository_WithPositiveBookCount_Saves()
    {
        var unitOfWork = new EFUnitOfWork(Context);

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
        
        var foundLibrary = unitOfWork.LibraryRepository.GetById(libraryId);
        Assert.True(foundLibrary?.Books.Count == 1);
    }
    
    [Fact]
    public async void GenreRepository_SameName_RollsBack()
    {
        var unitOfWork = new EFUnitOfWork(Context);

        var id = Guid.NewGuid();
        unitOfWork.GenreRepository.Insert(new Genre { Id = id, Name = "Horror" });
        unitOfWork.GenreRepository.Insert(new Genre { Id = Guid.NewGuid(), Name = "Horror" });
        
        await unitOfWork.Commit();

        var actual = unitOfWork.GenreRepository.GetById(id);
        Assert.True(actual == null);
    }
}