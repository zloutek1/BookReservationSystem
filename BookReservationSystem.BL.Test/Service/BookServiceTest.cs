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
    private readonly Mock<IQuery<Genre>> _genreQueryMock;
    private readonly Mock<IQuery<Author>> _authorQueryMock;
    private readonly Mock<IQuery<Publisher>> _publisherQueryMock;

    public BookServiceTest(IMapper mapper)
    {
        _mapper = mapper;
        _uowMock = new Mock<IUnitOfWork>();
        _bookRepositoryMock = new Mock<IRepository<Book>>();
        _bookQueryMock = new Mock<IQuery<Book>>();
        _genreQueryMock = new Mock<IQuery<Genre>>();
        _authorQueryMock = new Mock<IQuery<Author>>();
        _publisherQueryMock = new Mock<IQuery<Publisher>>();
    }

    [Fact]
    public async Task Insert_InsertsGiven()
    {
        var bookDto = new BookDto
        {
            Name = "TestName",
            Abstract = "TestAbstract",
            CoverArtPath = "test/cover/art",
            Isbn = 0001
        };

        var bookService = new BookService(_bookQueryMock.Object,  _bookRepositoryMock.Object, _mapper, ()=> _uowMock.Object, _genreQueryMock.Object, _authorQueryMock.Object, _publisherQueryMock.Object);

        await bookService.Insert(bookDto);
        
        _bookRepositoryMock.Verify(mock => 
            mock.Insert(
                It.Is<Book>(book => book.Name == "TestName")), 
            Times.Once());
        _uowMock.Verify(mock => mock.Commit(), Times.Once());
    }
}