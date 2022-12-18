using AutoMapper;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.BL.Query;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace BookReservationSystem.BL.Services;

public class BookService : CrudService<Book, BookDto>, IBookService
{
    private readonly IQuery<Genre> _qenreQuery;
    private readonly IQuery<Author> _authorQuery;
    private readonly IQuery<Publisher> _publisherQuery;

    public BookService(IQuery<Book> query, IRepository<Book> repository, IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, IQuery<Genre> qenreQuery, IQuery<Author> authorQuery, IQuery<Publisher> publisherQuery) : base(query, repository, mapper, unitOfWorkFactory)
    {
        _qenreQuery = qenreQuery;
        _authorQuery = authorQuery;
        _publisherQuery = publisherQuery;
    }

    public async Task<IEnumerable<BookDto>> FilterBooks(BookFilterDto filter)
    {
        var bookQuery = new FilterBookQuery(Mapper, Query);
        return await bookQuery.Execute(filter);
    }
    
    public async Task<BookDto> FindByReview(Guid reviewId)
    {
        var bookQuery = new GetBookByReviewQuery(Mapper, Query);
        return await bookQuery.Execute(reviewId);
    }
    
    public async Task Insert(BookCreateDto createDto)
    {
        var book = Mapper.Map<Book>(createDto);
        await using var uow = UnitOfWorkFactory();

        book.Id = Guid.NewGuid();
        book.CoverArtPath = await GetCoverArtPath(book.Id, createDto.CoverArt);
        book.Genres = (await _qenreQuery.Where(g => createDto.GenreIds.Contains(g.Id)).Execute()).ToList();
        book.Authors = (await _authorQuery.Where(a => createDto.AuthorIds.Contains(a.Id)).Execute()).ToList();
        book.Publishers = (await _publisherQuery.Where(p => createDto.PublisherIds.Contains(p.Id)).Execute()).ToList();

        await Repository.Insert(book);

        await uow.Commit();
    }

    public async Task Update(BookUpdateDto updateDto)
    {
        var book = Mapper.Map<Book>(updateDto);
        await using var uow = UnitOfWorkFactory();

        book.CoverArtPath = await GetCoverArtPath(updateDto.Id, updateDto.CoverArt);
        await Repository.Update(book);
        
        await uow.Commit();
    }

    public async Task<IEnumerable<BookDto>> FindAllNotInLibrary(Guid libraryId)
    {
        var bookQuery = new FilterBookNotInLibraryQuery(Mapper, Query);
        return await bookQuery.Execute(libraryId);
    }

    private static async Task<string> GetCoverArtPath(Guid id, IFormFile? coverArt)
    {
        var fileName = id + ".jpg";
        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\BookReservationSystem.MVC\\wwwroot\\book_covers", fileName);
        
        if (coverArt != null)
        {
            await SaveImage(coverArt, uploadPath);
        }

        if (File.Exists(uploadPath))
        {
            return "~/book_covers/" + fileName;
        }
        
        return "~/book_covers/empty.jpg";
    }

    private static async Task SaveImage(IFormFile image, string uploadPath)
    {
        await using var stream = new FileStream(uploadPath, FileMode.Create);
        await image.CopyToAsync(stream);
    }
}