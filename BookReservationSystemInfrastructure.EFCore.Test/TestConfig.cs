using BookReservationSystemDAL.Data;
using Microsoft.EntityFrameworkCore;

namespace BookReservationSystemInfrastructure.EFCore.Test;

public class TestConfig
{
    protected readonly BookReservationSystemDbContext Context;
    
    protected TestConfig()
    {
        var myDatabaseName = "myDatabase_" + DateTime.Now.ToFileTimeUtc();

        var dbContextOptions = new DbContextOptionsBuilder<BookReservationSystemDbContext>()
            .UseInMemoryDatabase(databaseName: myDatabaseName)
            .Options;

        Context = new BookReservationSystemDbContext(dbContextOptions);
    }
}