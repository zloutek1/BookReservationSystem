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
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly Func<IUnitOfWork> _unitOfWorkFactory;
        private readonly IRepository<Review> _reviewRepository;
        private readonly IQuery<Review> _reviewQuery;
        private readonly IRepository<Book> _bookRepository;

        public ReviewService(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, IRepository<Review> reviewRepository, IRepository<Book> bookRepository, IQuery<Review> reviewQuery)
        {
            _mapper = mapper;
            _unitOfWorkFactory = unitOfWorkFactory;
            _reviewRepository = reviewRepository;
            _bookRepository = bookRepository;
            _reviewQuery = reviewQuery;
        }

        #region crud
        public IEnumerable<ReviewDto> FindAll()
        {
            var foundReviews = _reviewRepository.FindAll();
            return _mapper.Map<IEnumerable<ReviewDto>>(foundReviews);
        }

        public ReviewDto? FindById(Guid id)
        {
            var foundReview = _reviewRepository.FindById(id);
            return _mapper.Map<ReviewDto?>(foundReview);
        }

        public void Insert(ReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);

            var reviewQuery = new GetReviewAuthorQuery(_mapper, _reviewQuery);
            var book = _mapper.Map<Book>(reviewQuery.Execute(reviewDto));

            float temp = 0;
            foreach (Review r in book.Reviews)
            {
                temp += r.Rating;
            }
            temp += review.Rating;
            temp /= book.Reviews.Count + 1;

            book.AverageRating = temp;

            using var uow = _unitOfWorkFactory();
            _bookRepository.Update(book);
            _reviewRepository.Insert(review);
            uow.Commit();
        }

        public void Update(ReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            using var uow = _unitOfWorkFactory();
            _reviewRepository.Update(review);
            uow.Commit();
        }

        public void Delete(Guid id)
        {
            using var uow = _unitOfWorkFactory();
            _reviewRepository.Delete(id);
            uow.Commit();
        }
        #endregion

        public IEnumerable<ReviewDto> FindAllFromUser(string email)
        {
            var reviewQuery = new FilterReviewsQuery(_mapper, _reviewQuery);
            return reviewQuery.Execute(new ReviewUserFilterDto() { Email = email, SortAscending = true });
        }
    }
}
