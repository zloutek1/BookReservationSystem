using AutoMapper;
using BookReservationSystem.BL.Services;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Moq;

namespace BookReservationSystem.BL.Test.Service;

public class BookServiceTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IRepository<Book>> _bookRepositoryMock;
    private readonly Mock<IUnitOfWork> _uowMock;

    public BookServiceTest(IMapper mapper)
    {
        _mapper = mapper;
        _bookRepositoryMock = new Mock<IRepository<Book>>();
        _uowMock = new Mock<IUnitOfWork>();
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

        var bookService = new BookService(_mapper, ()=> _uowMock.Object, _bookRepositoryMock.Object);

        bookService.Insert(bookDto);
        
        _bookRepositoryMock.Verify(mock => 
            mock.Insert(
                It.Is<Book>(book => book.Name == "TestName")), 
            Times.Once());
        _uowMock.Verify(mock => mock.Commit(), Times.Once());
    }
}