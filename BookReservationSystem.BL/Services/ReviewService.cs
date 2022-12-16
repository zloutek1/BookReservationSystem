using AutoMapper;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.BL.Query;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.BL.Services
{
    public class ReviewService : CrudService<Review, ReviewDto>, IReviewService
    {
        private readonly IRepository<Book> _bookRepository;

        public ReviewService(IQuery<Review> query, IRepository<Review> repository, IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, IRepository<Book> bookRepository) : base(query, repository, mapper, unitOfWorkFactory)
        {
            _bookRepository = bookRepository;
        }

        public new async Task Insert(ReviewDto reviewDto)
        {
            var review = Mapper.Map<Review>(reviewDto);

            var reviewQuery = new GetReviewAuthorQuery(Mapper, Query);
            var book = Mapper.Map<Book>(reviewQuery.Execute(reviewDto));

            var temp = book.Reviews.Aggregate<Review, float>(0, (current, r) => current + r.Rating);
            temp += review.Rating;
            temp /= book.Reviews.Count + 1;
            book.AverageRating = temp;

            await using var uow = UnitOfWorkFactory();
            await _bookRepository.Update(book);
            await Repository.Insert(review);
            await uow.Commit();
        }
        
        public IEnumerable<ReviewDto> FindAllFromUser(string email)
        {
            // TODO: fix this as well
            //var reviewQuery = new FilterReviewsQuery(Mapper, Query);
            //return reviewQuery.Execute(new ReviewUserFilterDto { Email = email, SortAscending = true });
            return new List<ReviewDto>();
        }

        public IEnumerable<ReviewDto> FindAllForBook(Guid bookId)
        {
            var reviewQuery = new GetBookReviewsQuery(Mapper, Query);
            return reviewQuery.Execute(new BookDto { Id = bookId });
        }
    }
}
