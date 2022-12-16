using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookReservationSystem.Infrastructure.EFCore.Test.Repository;

public class GenericRepositoryTests : IDisposable
{
    private readonly DatabaseFixture _databaseFixture;

    public GenericRepositoryTests()
    {
        _databaseFixture = new DatabaseFixture();
    }

    [Fact]
    public async void GetById_Genre_ReturnNull()
    {
        Genre? current;
        await using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            current = await repository.FindById(Guid.NewGuid());
        }

        Assert.Null(current);
    }

    [Fact]
    public async void Insert_Genre_Inserts()
    {
        var romance = new Genre { Id = Guid.NewGuid(), Name = "Romance" };

        await using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            await repository.Insert(romance);
            await repository.Commit();
        }

        Genre? current;
        await using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            current = await repository.FindById(romance.Id);
        }

        Assert.Equal("Romance", current?.Name);
    }

    [Fact]
    public async void Insert_GenresWithSameId_Throws()
    {
        var id = Guid.NewGuid();
        var romance = new Genre { Id = id, Name = "Romance" };
        var bromance = new Genre { Id = id, Name = "Bromance" };

        await using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            await repository.Insert(romance);
            await repository.Commit();
        }

        await Assert.ThrowsAsync<DbUpdateException>(async () =>
        {
            await using var context = _databaseFixture.CreateContext();
            var repository = new GenericRepository<Genre>(context);
            await repository.Insert(bromance);
            await repository.Commit();
        });
    }

    [Fact]
    public async void Update_Genre_Updates()
    {
        var romance = new Genre { Id = Guid.NewGuid(), Name = "Romance" };

        await using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            await repository.Insert(romance);
            await repository.Commit();
        }

        romance.Name = "Bromance";

        await using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            await repository.Update(romance);
            await repository.Commit();
        }

        Genre? current;
        await using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            current = await repository.FindById(romance.Id);
        }

        Assert.Equal("Bromance", current?.Name);
    }

    [Fact]
    public async void Delete_Genre_Deletes()
    {
        var romance = new Genre { Id = Guid.NewGuid(), Name = "Romance" };

        await using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            await repository.Insert(romance);
            await repository.Commit();
        }

        await using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            await repository.Delete(romance.Id);
            await repository.Commit();
        }

        Genre? current;
        await using (var context = _databaseFixture.CreateContext())
        {
            var repository = new GenericRepository<Genre>(context);
            current = await repository.FindById(romance.Id);
        }

        Assert.Null(current);
    }

    [Fact]
    public async void Delete_AbsentGenre_Throws()
    {
        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            await using var context = _databaseFixture.CreateContext();
            var repository = new GenericRepository<Genre>(context);
            await repository.Delete(Guid.NewGuid());
            await repository.Commit();
        });
    }

    public void Dispose()
    {
        _databaseFixture.Dispose();
    }
}