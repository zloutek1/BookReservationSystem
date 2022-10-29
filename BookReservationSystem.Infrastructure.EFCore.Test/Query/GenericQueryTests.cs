using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Query;

namespace BookReservationSystem.Infrastructure.EFCore.Test.Query;

public class GenericQueryTests: IDisposable
{
    private readonly DatabaseFixture _databaseFixture;
    private readonly BookReservationSystemDbContext _context;
    
    public GenericQueryTests()
    {
        _databaseFixture = new DatabaseFixture();
        _context = _databaseFixture.CreateContext();
        
        SaveGenre("Comedy");
        SaveGenre("European");
        SaveGenre("Educational");

        SaveBook("Green");
        SaveBook("Hacker");
        SaveBook("Hammer");

        _context.SaveChanges();
    }
    
    [Fact]
    public void Where_GivenBooksWithName_ReturnsOne()
    {
        var query = new GenericQuery<Book>(_context);
        query.Where<string>(a => a == "Hacker", "Name");
        var result = query.Execute().ToList();

        Assert.True(result.Count == 1);
        Assert.True(result.First().Name == "Hacker");
    }
    
    [Fact]
    public void Where_GivenBooksNameStartsWith_ReturnsTwo()
    {
        var query = new GenericQuery<Book>(_context);
        query.Where<string>(a => a.StartsWith("Ha"), "Name");
        var result = query.Execute().ToList();

        Assert.True(result.Count == 2);
    }
    
    [Fact]
    public void Where_GivenGenresNameStartsWith_ReturnsTwo()
    {
        var query = new GenericQuery<Genre>(_context);
        query.Where<string>(a => a.StartsWith("E"), "Name");
        var result = query.Execute().ToList();

        Assert.True(result.Count == 2);
    }
    
    [Fact]
    public void Where_PredicateAlwaysTrue_ReturnsAll()
    {
        var query = new GenericQuery<Book>(_context);
        query.Where<string>(a => true, "Name");
        var result = query.Execute();

        Assert.Equal(3, result.Count());
    }
    
    [Fact]
    public void Where_PredicateAlwaysFalse_ReturnsNone()
    {
        var query = new GenericQuery<Book>(_context);
        query.Where<string>(a => false, "Name");
        var result = query.Execute();

        Assert.Empty(result);
    }
    
    [Fact]
    public void OrderByAscending_GivenBooksWithName_ReturnsOrdered()
    {
        var query = new GenericQuery<Book>(_context);
        query.OrderBy<string>("Name");
        var result = query.Execute()
            .Select(a => a.Name)
            .ToList();

        var expectedResult = _context.Book
            .Select(a => a.Name)
            .OrderBy(a => a)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void WhereOrderByAscending_GivenGenreWithName_ReturnsOrdered()
    {
        var query = new GenericQuery<Genre>(_context);
        query.Where<string>(a => a.StartsWith("E"), "Name");
        query.OrderBy<string>("Name");
        var result = query.Execute()
            .Select(a => a.Name)
            .ToList();

        var expectedResult = new List<string> { "Educational", "European" };

        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void OrderByDescending_GivenBooksWithName_ReturnsOrdered()
    {
        var query = new GenericQuery<Book>(_context);
        query.OrderBy<string>("Name", false);
        var result = query.Execute()
            .Select(a => a.Name)
            .ToList();

        var expectedResult = _context.Book
            .Select(a => a.Name)
            .OrderByDescending(a => a)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Page_GivenFirstPage_ReturnsOne()
    {
        var query = new GenericQuery<Book>(_context);
        query.Page(1, 1);
        
        var result = query.Execute()
            .Select(a => a.Name)
            .ToList();

        var expectedResult = _context.Book
            .Take(1)
            .Select(a => a.Name)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Page_GivenSecondPage_ReturnsOne()
    {
        var query = new GenericQuery<Book>(_context);
        query.Page(2, 2);
        
        var result = query.Execute()
            .Select(a => a.Name)
            .ToList();

        var expectedResult = _context.Book
            .Skip(2)
            .Take(2)
            .Select(a => a.Name)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
    
    private void SaveBook(string name) 
    { 
        _context.Book.Add(new Book
        {
            Id = Guid.NewGuid(), 
            Name = name, 
            Abstract = "Definitely not null",
            Isbn = 0
        });
    }
    
    private void SaveGenre(string name) 
    { 
        _context.Genre.Add(new Genre()
        {
            Id = Guid.NewGuid(), 
            Name = name,
        });
    }

    public void Dispose()
    {
        _context.Dispose();
        _databaseFixture.Dispose();
    }
}
