using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Repository;
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
            await using (var uow = new GenericUnitOfWork(context))
            {
                var book = new Book
                {
                    Id = bookId,
                    Abstract = "",
                    Isbn = 123456789L,
                    CoverArtPath = "../Resources/example.jpg",
                    Name = "BooName"
                };
                
                var bookRepo = new GenericRepository<Book>(context);
                await bookRepo.Insert(book);

                var address = new Address
                {
                    Id = addressId,
                    City = "A",
                    Country = "B",
                    PostalCode = "C",
                    Street = "D",
                    StreetNumber = 1
                };
                
                var addressRepo = new GenericRepository<Address>(context);
                await addressRepo.Insert(address); 
                
                var library = new Library
                {
                    Id = libraryId,
                    Name = "Dobrovsky",
                    AddressId = addressId,
                    Books = new List<BookQuantity> { new() { BookId = bookId, LibraryId = libraryId, Count = 4 } }
                };
                
                var libraryRepo = new GenericRepository<Library>(context);
                await libraryRepo.Insert(library);
                
                await uow.Commit();
            }
        }

        Library? foundLibrary;
        await using (var context = _databaseFixture.CreateContext())
        {
            var libraryRepo = new GenericRepository<Library>(context);
            foundLibrary = await libraryRepo.FindById(libraryId);
            
            Assert.NotNull(foundLibrary);
            await context.Entry(foundLibrary!).Collection("Books").LoadAsync();
        }
        
        Assert.Single(foundLibrary!.Books);
    }
    
    [Fact]
    public async void GenreRepository_SameName_Throws()
    {
        await using var context = _databaseFixture.CreateContext();
        await using var unitOfWork = new GenericUnitOfWork(context);

        var genreRepo = new GenericRepository<Genre>(context);
        await genreRepo.Insert(new Genre { Id = Guid.NewGuid(), Name = "Horror" });
        await genreRepo.Insert(new Genre { Id = Guid.NewGuid(), Name = "Horror" });
            
        await Assert.ThrowsAsync<DbUpdateException>(async () => await unitOfWork.Commit());
    }
    
    public void Dispose()
    {
        _databaseFixture.Dispose();
    }
}