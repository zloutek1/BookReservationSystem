using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.EFCore.Query;

namespace BookReservationSystemInfrastructure.EFCore.Test.Query;

public class GenericQueryTests : TestConfig
{
    public GenericQueryTests()
    {

        var johnny = new Author { Id = Guid.NewGuid(), Name = "Johnny B" };
        var dude = new Author { Id = Guid.NewGuid(), Name = "Dude" };
        Context.Author.Add(johnny);
        Context.Author.Add(dude);

        var satire = new Genre { Id = Guid.NewGuid(), Name = "Satire" };
        var horror = new Genre { Id = Guid.NewGuid(), Name = "Horror" };
        Context.Genre.Add(satire);
        Context.Genre.Add(horror);
        
        SaveBook("Green -> Red", new List<Author>{johnny}, new List<Genre>{horror});
        SaveBook("Hacker", new List<Author>{dude}, new List<Genre>{satire});
        SaveBook("Hammer", new List<Author>{dude}, new List<Genre>{satire});

        Context.SaveChanges();
    }
    
    [Fact]
    public void Where_GivenBooksWithName_ReturnsOne()
    {
        var query = new GenericQuery<Book>(Context);
        query.Where<string>(a => a == "Hacker", "Name");
        var result = query.Execute().ToList();

        Assert.True(result.Count == 1);
        Assert.True(result.First().Name == "Hacker");
    }
    
    [Fact]
    public void Where_GivenBooksNameStartsWith_ReturnsTwo()
    {
        var query = new GenericQuery<Book>(Context);
        query.Where<string>(a => a.StartsWith("Ha"), "Name");
        var result = query.Execute().ToList();

        Assert.True(result.Count == 2);
    }
    
    [Fact]
    public void OrderByAscending_GivenBooksWithName_ReturnsOrdered()
    {
        var query = new GenericQuery<Book>(Context);
        query.OrderBy<string>("Name");
        var result = query.Execute()
            .Select(a => a.Name)
            .ToList();

        var expectedResult = Context.Book
            .Select(a => a.Name)
            .OrderBy(a => a)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void OrderByDescending_GivenBooksWithName_ReturnsOrdered()
    {
        var query = new GenericQuery<Book>(Context);
        query.OrderBy<string>("Name", false);
        var result = query.Execute()
            .Select(a => a.Name)
            .ToList();

        var expectedResult = Context.Book
            .Select(a => a.Name)
            .OrderByDescending(a => a)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Page_GivenFirstPage_ReturnsOne()
    {
        var query = new GenericQuery<Book>(Context);
        query.Page(1, 1);
        
        var result = query.Execute()
            .Select(a => a.Name)
            .ToList();

        var expectedResult = Context.Book
            .Take(1)
            .Select(a => a.Name)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Page_GivenSecondPage_ReturnsOne()
    {
        var query = new GenericQuery<Book>(Context);
        query.Page(2, 2);
        
        var result = query.Execute()
            .Select(a => a.Name)
            .ToList();

        var expectedResult = Context.Book
            .Skip(2)
            .Take(2)
            .Select(a => a.Name)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
    
    private void SaveBook(string name, List<Author> authors, List<Genre> genres) 
    { 
        Context.Book.Add(new Book
        {
            Id = Guid.NewGuid(), 
            Name = name, 
            Abstract = "Definitely not null", 
            Authors = authors, 
            Genres = genres, 
            Publishers = new List<Publisher>(), 
            Reviews = new List<Review>(), 
            CoverArtUrl = "not null", 
            Isbn = 0
        });
    }
}
