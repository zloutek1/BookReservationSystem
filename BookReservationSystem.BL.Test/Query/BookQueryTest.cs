using AutoMapper;
using BookReservationSystem.BL.Query;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using Moq;

namespace BookReservationSystem.BL.Test.Query;

public class BookQueryTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IQuery<Book>> _bookQueryMock;
    
    public BookQueryTest(IMapper mapper)
    {
        _mapper = mapper;
        _bookQueryMock = new Mock<IQuery<Book>>();
    }
    
    [Fact]
    public void Where_GivenBooksWithName_ReturnsOne()
    {
        var filteredBooks = new List<Book>
        {
            new() { Name = "Hacker"  }
        };

        _bookQueryMock
            .Setup(x => x.Execute())
            .Returns(filteredBooks);
        
        var query = new FilterBookQuery(_mapper, _bookQueryMock.Object);
        var filters = new BookFilterDto { Name = "Hacker" };
        
        var result = query.Execute(filters).ToList();
        
        Assert.Single(result);
        Assert.Equal("Hacker", result.First().Name);
    }
    
}