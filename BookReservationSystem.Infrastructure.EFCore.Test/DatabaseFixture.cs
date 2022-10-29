using System.Data.Common;
using BookReservationSystem.DAL.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BookReservationSystem.Infrastructure.EFCore.Test;

public class DatabaseFixture: IDisposable
{
    private readonly DbConnection _connection;
    private readonly DbContextOptions<BookReservationSystemDbContext> _contextOptions;

    public DatabaseFixture()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        
        _contextOptions = new DbContextOptionsBuilder<BookReservationSystemDbContext>()
            .UseSqlite(_connection)
            .Options;
        
        using var context = CreateContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    public BookReservationSystemDbContext CreateContext() => new(_contextOptions, shouldSeed: false);

    public void Dispose()
    {
        _connection.Dispose();
    }
}