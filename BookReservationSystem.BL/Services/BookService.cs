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
    public BookService(IQuery<Book> query, IRepository<Book> repository, IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory) : base(query, repository, mapper, unitOfWorkFactory)
    {
        
    }

    public async Task<IEnumerable<BookDto>> FilterBooks(BookFilterDto filter)
    {
        var bookQuery = new FilterBookQuery(Mapper, Query);
        return await bookQuery.Execute(filter);
    }
    
    public async Task Insert(BookCreateDto createDto)
    {
        var book = Mapper.Map<Book>(createDto);
        await using var uow = UnitOfWorkFactory();

        if (createDto.CoverArt != null)
        {
            book.CoverArtPath = await SaveImage(createDto.CoverArt);
        }
        await Repository.Insert(book);
        
        await uow.Commit();
    }

    private static async Task<string> SaveImage(IFormFile image)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\BookReservationSystem.MVC\\wwwroot\\book_covers", fileName);
        var stream = new FileStream(uploadPath, FileMode.Create);
        await image.CopyToAsync(stream);
        return "~/book_covers/"+fileName;
    }
}