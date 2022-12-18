using AutoMapper;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.BL.Query;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using BookReservationSystem.BL.Exceptions;

namespace BookReservationSystem.BL.Services;

public class ReviewService : CrudService<Review, ReviewDto>, IReviewService
{
    private readonly IRepository<Book> _bookRepository;
    private readonly UserManager<User> _userManager;
    private readonly IQuery<Book> _bookQuery;

    public ReviewService(IQuery<Review> query, IRepository<Review> repository, IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, IRepository<Book> bookRepository, UserManager<User> userManager, IQuery<Book> bookQuery) : base(query, repository, mapper, unitOfWorkFactory)
    {
        _bookRepository = bookRepository;
        _userManager = userManager;
        _bookQuery = bookQuery;
    }

    public async Task Insert(ReviewCreateDto reviewCreateDto)
    {
        var review = Mapper.Map<Review>(reviewCreateDto);

        var user = await _userManager.FindByNameAsync(reviewCreateDto.UserName);
        if (user == null)
        {
            throw new NotFoundException($"User with name {reviewCreateDto.UserName} not found");
        }
        review.UserId = user.Id;

        
        var book = await _bookRepository.FindById(reviewCreateDto.BookId);
        if (book == null)
        {
            throw new NotFoundException($"Book with id {reviewCreateDto.BookId} not found");
        }
        var temp = book.Reviews.Aggregate<Review, float>(0, (current, r) => current + r.Rating);
        temp += review.Rating;
        temp /= book.Reviews.Count + 1;
        book.Rating = temp;

        await using var uow = UnitOfWorkFactory();
        try
        {
            await Repository.Insert(review);
            await _bookRepository.Update(book);
            await uow.Commit();
        } 
        catch (Exception ex)
        {
            await uow.Rollback();
            throw new ServiceException("Could not insert review", ex);
        }
    }

    public new async Task Delete(Guid id)
    {
        var review = await Repository.FindById(id);
        if (review == null)
        {
            throw new NotFoundException($"Review with id {id} not found");
        }

        var book = (await _bookQuery.Where(b => b.Reviews.Any(r => r.Id == id)).Execute()).FirstOrDefault();
        if (book == null)
        {
            throw new NotFoundException($"Book for review with id {id} not found");
        }

        var temp = book.Reviews.Aggregate<Review, float>(0, (current, r) => current + r.Rating);
        temp -= review.Rating;
        if (book.Reviews.Count != 1)
        {
            temp /= book.Reviews.Count - 1;
        }
        book.Rating = temp;

        await using var uow = UnitOfWorkFactory();
        try
        {
            await _bookRepository.Update(book);
            await Repository.Delete(id);
            await uow.Commit();
        } 
        catch (Exception ex)
        {
            await uow.Rollback();
            throw new ServiceException("Could not delete review", ex);
        }
    }

    public async Task<IEnumerable<ReviewDto>> FindAllFromUser(Guid userId)
    {
        var reviewQuery = new GetUserReviewsQuery(Mapper, Query);
        return await reviewQuery.Execute(new UserDto { Id = userId });
    }

    public async Task<IEnumerable<ReviewDto>> FindAllForBook(Guid bookId)
    {
        var reviewQuery = new GetBookReviewsQuery(Mapper, Query);
        return await reviewQuery.Execute(new BookDto { Id = bookId });
    }
}