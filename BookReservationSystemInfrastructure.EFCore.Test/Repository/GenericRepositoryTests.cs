using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.EFCore.Repository;

namespace BookReservationSystemInfrastructure.EFCore.Test.Repository;

public class GenericRepositoryTests : TestConfig
{
    
    [Fact]
    public void GetById_Genre_ReturnNull()
    {
        var repository = new GenericRepository<Genre>(Context);
        var actual = repository.GetById(Guid.NewGuid());
        
        Assert.True(actual == null);
    }
    
    [Fact]
    public void Insert_Genre_Inserts()
    {
        var romance = new Genre { Id = Guid.NewGuid(), Name = "Romance" };
        
        var repository = new GenericRepository<Genre>(Context);
        repository.Insert(romance);
        var actual = repository.GetById(romance.Id);
        
        Assert.True(actual?.Equals(romance));
    }
    
    [Fact]
    public void Insert_GenresWithSameId_Throws()
    {
        var id = Guid.NewGuid();
        var romance = new Genre { Id = id, Name = "Romance" };
        var bromance = new Genre { Id = id, Name = "Bromance" };
        
        var repository = new GenericRepository<Genre>(Context);
        repository.Insert(romance);

        Assert.Throws<InvalidOperationException>(() => repository.Insert(bromance));
    }
    
    [Fact]
    public void Update_Genre_Updates()
    {
        var romance = new Genre { Id = Guid.NewGuid(), Name = "Romance" };
        
        var repository = new GenericRepository<Genre>(Context);
        repository.Insert(romance);
        romance.Name = "Bromance";
        repository.Update(romance);
        var actual = repository.GetById(romance.Id);
        
        Assert.True(actual?.Equals(romance));
    }
    
    [Fact]
    public void Delete_Genre_Deletes()
    {
        var romance = new Genre { Id = Guid.NewGuid(), Name = "Romance" };
        
        var repository = new GenericRepository<Genre>(Context);
        repository.Insert(romance);
        repository.Delete(romance.Id);
        var actual = repository.GetById(romance.Id);

        Assert.True(actual == null);
    }
    
    [Fact]
    public void Delete_AbsentGenre_Throws()
    {
        var repository = new GenericRepository<Genre>(Context);
        
        Assert.Throws<ArgumentException>(() => repository.Delete(Guid.NewGuid()));
    }

}