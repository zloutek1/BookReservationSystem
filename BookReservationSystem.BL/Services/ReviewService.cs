using AutoMapper;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.BL.Query;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.BL.Services
{
    public class ReviewService : CrudService<Review, ReviewDto>, IReviewService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly UserManager<User> _userManager;

        public ReviewService(IQuery<Review> query, IRepository<Review> repository, IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, IRepository<Book> bookRepository, UserManager<User> userManager) : base(query, repository, mapper, unitOfWorkFactory)
        {
            _bookRepository = bookRepository;
            _userManager = userManager;
        }

        public async Task Insert(ReviewCreateDto reviewCreateDto)
        {
            var review = Mapper.Map<Review>(reviewCreateDto);

            var book = await _bookRepository.FindById(reviewCreateDto.BookId);

            var temp = book.Reviews.Aggregate<Review, float>(0, (current, r) => current + r.Rating);
            temp /= book.Reviews.Count + 1;
            book.Rating = temp;

            var user = await _userManager.FindByNameAsync(reviewCreateDto.UserName);
            review.UserId = user.Id;

            await using var uow = UnitOfWorkFactory();
            await Repository.Insert(review);
            await _bookRepository.Update(book);
            await uow.Commit();
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
}
