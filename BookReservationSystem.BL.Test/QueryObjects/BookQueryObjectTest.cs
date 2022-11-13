using AutoMapper;
using BookReservationSystem.BL.Configs;
using BookReservationSystem.BL.QueryObjects;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using Moq;

namespace BookReservationSystem.BL.Test.QueryObjects;

public class BookQueryObjectTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IQuery<Book>> _bookQueryMock;
    
    public BookQueryObjectTest()
    {
        _mapper = new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping));
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
        
        var query = new BookQueryObject(_mapper, _bookQueryMock.Object);
        var filters = new BookFilterDto { Name = "Hacker" };
        
        var result = query.Execute(filters).ToList();
        
        Assert.Single(result);
        Assert.Equal("Hacker", result.First().Name);
    }
    
}