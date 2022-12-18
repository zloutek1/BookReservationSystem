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

        SaveBook("Green", 1);
        SaveBook("Hacker", 2);
        SaveBook("Hammer", 3);

        _context.SaveChanges();
    }
    
    [Fact]
    public async Task Where_GivenBooksWithName_ReturnsOne()
    {
        var query = new GenericQuery<Book>(_context);
        query.Where(b => b.Name == "Hacker");
        var result = (await query.Execute()).ToList();

        Assert.True(result.Count == 1);
        Assert.True(result.First().Name == "Hacker");
    }
    
    [Fact]
    public async Task Where_GivenBooksNameStartsWith_ReturnsTwo()
    {
        var query = new GenericQuery<Book>(_context);
        query.Where(b => b.Name.StartsWith("Ha"));
        var result = (await query.Execute()).ToList();

        Assert.True(result.Count == 2);
    }
    
    [Fact]
    public async Task Where_GivenGenresNameStartsWith_ReturnsTwo()
    {
        var query = new GenericQuery<Genre>(_context);
        query.Where(g => g.Name.StartsWith("E"));
        var result = (await query.Execute()).ToList();

        Assert.True(result.Count == 2);
    }
    
    [Fact]
    public async Task Where_PredicateAlwaysTrue_ReturnsAll()
    {
        var query = new GenericQuery<Book>(_context);
        query.Where(b => true);
        var result = await query.Execute();

        Assert.Equal(3, result.Count());
    }
    
    [Fact]
    public async Task Where_PredicateAlwaysFalse_ReturnsNone()
    {
        var query = new GenericQuery<Book>(_context);
        query.Where(b => false);
        var result = await query.Execute();

        Assert.Empty(result);
    }
    
    [Fact]
    public async Task OrderByAscending_GivenBooksWithName_ReturnsOrdered()
    {
        var query = new GenericQuery<Book>(_context);
        query.OrderBy(b => b.Name);
        var result = (await query.Execute())
            .Select(a => a.Name)
            .ToList();

        var expectedResult = _context.Book
            .Select(a => a.Name)
            .OrderBy(a => a)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public async Task WhereOrderByAscending_GivenGenreWithName_ReturnsOrdered()
    {
        var query = new GenericQuery<Genre>(_context);
        query.Where(g => g.Name.StartsWith("E"));
        query.OrderBy(g => g.Name);
        var result = (await query.Execute())
            .Select(a => a.Name)
            .ToList();

        var expectedResult = new List<string> { "Educational", "European" };

        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public async Task OrderByDescending_GivenBooksWithName_ReturnsOrdered()
    {
        var query = new GenericQuery<Book>(_context);
        query.OrderBy(b => b.Name, false);
        var result = (await query.Execute())
            .Select(a => a.Name)
            .ToList();

        var expectedResult = _context.Book
            .Select(a => a.Name)
            .OrderByDescending(a => a)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public async Task Page_GivenFirstPage_ReturnsOne()
    {
        var query = new GenericQuery<Book>(_context);
        query.Page(1, 1);
        
        var result = (await query.Execute())
            .Select(a => a.Name)
            .ToList();

        var expectedResult = _context.Book
            .Take(1)
            .Select(a => a.Name)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public async Task Page_GivenSecondPage_ReturnsOne()
    {
        var query = new GenericQuery<Book>(_context);
        query.Page(2, 2);
        
        var result = (await query.Execute())
            .Select(a => a.Name)
            .ToList();

        var expectedResult = _context.Book
            .Skip(2)
            .Take(2)
            .Select(a => a.Name)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
    
    private void SaveBook(string name, long isbn) 
    { 
        _context.Book.Add(new Book
        {
            Id = Guid.NewGuid(), 
            Name = name, 
            Abstract = "Definitely not null",
            Isbn = isbn
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
