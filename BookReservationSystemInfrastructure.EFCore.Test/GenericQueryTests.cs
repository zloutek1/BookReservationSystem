using BookReservationSystemDAL.Models;
using BookReservationSystemInfrastructure.EFCore.Query;

namespace BookReservationSystemInfrastructure.EFCore.Test;

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

        Context.SaveChanges();
    }
    
    [Fact]
    public void Where_GivenBooksWithName_ReturnsOne()
    {
        var efQuery = new GenericQuery<Book>(Context);
        efQuery.Where<string>(a => a == "Hacker", "Name");
        var result = efQuery.Execute().ToList();

        Assert.True(result.Count == 1);
        Assert.True(result.First().Name == "Hacker");
    }
    
    [Fact]
    public void OrderBy_GivenBooksWithName_ReturnsOrdered()
    {
        var efQuery = new GenericQuery<Book>(Context);
        efQuery.OrderBy<string>("Name");
        var result = efQuery.Execute()
            .Select(a => a.Name)
            .ToList();

        var expectedResult = Context.Book
            .Select(a => a.Name)
            .OrderBy(a => a)
            .ToList();
        
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Page_GivenBooksWithName_ReturnsOne()
    {
        var efQuery = new GenericQuery<Book>(Context);
        efQuery.Page(1, 1);
        
        var result = efQuery.Execute()
            .Select(a => a.Name)
            .ToList();

        var expectedResult = Context.Book
            .Take(1)
            .Select(a => a.Name)
            .OrderBy(a => a)
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
            ISBN = 0
        }); 

    }
}
