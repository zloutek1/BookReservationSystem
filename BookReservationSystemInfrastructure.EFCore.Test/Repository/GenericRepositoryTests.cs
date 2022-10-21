using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookReservationSystemInfrastructure.EFCore.Test.Repository;

public class GenericRepositoryTests : IDisposable
{
    private readonly DatabaseFixture _databaseFixture;

    public GenericRepositoryTests()
    {
        _databaseFixture = new DatabaseFixture();
    }

    [Fact]
    public void GetById_Genre_ReturnNull()
    {
        Genre? actual;
        using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            actual = repository.GetById(Guid.NewGuid());
        }

        Assert.Null(actual);
    }

    [Fact]
    public void Insert_Genre_Inserts()
    {
        var romance = new Genre { Id = Guid.NewGuid(), Name = "Romance" };

        using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            repository.Insert(romance);
            repository.Commit();
        }

        Genre? actual;
        using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            actual = repository.GetById(romance.Id);
        }

        Assert.Equal("Romance", actual?.Name);
    }

    [Fact]
    public void Insert_GenresWithSameId_Throws()
    {
        var id = Guid.NewGuid();
        var romance = new Genre { Id = id, Name = "Romance" };
        var bromance = new Genre { Id = id, Name = "Bromance" };

        using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            repository.Insert(romance);
            repository.Commit();
        }

        Assert.Throws<DbUpdateException>(() =>
        {
            using var context = _databaseFixture.CreateContext();
            var repository = new GenericRepository<Genre>(context);
            repository.Insert(bromance);
            repository.Commit();
        });
    }

    [Fact]
    public void Update_Genre_Updates()
    {
        var romance = new Genre { Id = Guid.NewGuid(), Name = "Romance" };

        using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            repository.Insert(romance);
            repository.Commit();
        }

        romance.Name = "Bromance";

        using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            repository.Update(romance);
            repository.Commit();
        }

        Genre? actual;
        using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            actual = repository.GetById(romance.Id);
        }

        Assert.Equal("Bromance", actual?.Name);
    }

    [Fact]
    public void Delete_Genre_Deletes()
    {
        var romance = new Genre { Id = Guid.NewGuid(), Name = "Romance" };

        using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            repository.Insert(romance);
            repository.Commit();
        }

        using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            repository.Delete(romance.Id);
            repository.Commit();
        }

        Genre? actual;
        using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            actual = repository.GetById(romance.Id);
        }

        Assert.Null(actual);
    }

    [Fact]
    public void Delete_AbsentGenre_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            using var context = _databaseFixture.CreateContext();
            var repository = new GenericRepository<Genre>(context);
            repository.Delete(Guid.NewGuid());
            repository.Commit();
        });
    }

    public void Dispose()
    {
        _databaseFixture.Dispose();
    }
}