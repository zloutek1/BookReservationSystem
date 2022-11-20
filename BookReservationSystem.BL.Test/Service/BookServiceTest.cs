using AutoMapper;
using BookReservationSystem.BL.Services;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Moq;

namespace BookReservationSystem.BL.Test.Service;

public class BookServiceTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _uowMock;
    private readonly Mock<IRepository<Book>> _bookRepositoryMock;
    private readonly Mock<IQuery<Book>> _bookQueryMock;

    public BookServiceTest(IMapper mapper)
    {
        _mapper = mapper;
        _uowMock = new Mock<IUnitOfWork>();
        _bookRepositoryMock = new Mock<IRepository<Book>>();
        _bookQueryMock = new Mock<IQuery<Book>>();
    }

    [Fact]
    public void Insert_InsertsGiven()
    {
        var bookDto = new BookDto
        {
            Name = "TestName",
            Abstract = "TestAbstract",
            CoverArtPath = "test/cover/art",
            Isbn = 0001
        };

        var bookService = new BookService(_mapper, ()=> _uowMock.Object, _bookRepositoryMock.Object, _bookQueryMock.Object);

        bookService.Insert(bookDto);
        
        _bookRepositoryMock.Verify(mock => 
            mock.Insert(
                It.Is<Book>(book => book.Name == "TestName")), 
            Times.Once());
        _uowMock.Verify(mock => mock.Commit(), Times.Once());
    }
}