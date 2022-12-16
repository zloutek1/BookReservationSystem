using AutoMapper;
using BookReservationSystem.BL.Exceptions;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.BL.Query;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace BookReservationSystem.BL.Services;

public class ReservationService : CrudService<Reservation, ReservationDto>, IReservationService
{
    private readonly UserManager<User> _userManager;
    private readonly IRepository<BookQuantity> _bookQuantityRepository;

    public ReservationService(IQuery<Reservation> query, IRepository<Reservation> repository, IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, UserManager<User> userManager, IRepository<BookQuantity> bookQuantityRepository) : base(query, repository, mapper, unitOfWorkFactory)
    {
        _userManager = userManager;
        _bookQuantityRepository = bookQuantityRepository;
    }

    public async Task Insert(ReservationCreateDto createDto)
    {
        var reservation = Mapper.Map<Reservation>(createDto);
        
        var user = await _userManager.FindByNameAsync(createDto.UserName);
        reservation.CustomerId = user.Id;

        await using var uow = UnitOfWorkFactory();
        await Repository.Insert(reservation);
        await uow.Commit();
    }

    public async Task PickupBook(Guid reservationId)
    {
        var reservation = await Repository.FindById(reservationId);
        if (reservation == null)
        {
            throw new NotFoundException($"Reservation with id {reservationId} not found");
        }
        
        var bookQuantity = FindBookQuantity(reservation);
        if (bookQuantity == null)
        {
            throw new NotFoundException($"Book quantity for reservation {reservationId} not found");
        }
        
        if (bookQuantity.Count <= 0)
        {
            throw new ServiceException($"Book {reservation.Book.Name} is not available at {reservation.Library.Name} at the moment");
        }

        reservation.PickupDate = DateTime.Now;
        bookQuantity.Count -= 1;

        var uow = UnitOfWorkFactory();
        await Repository.Update(reservation);
        await _bookQuantityRepository.Update(bookQuantity);
        await uow.Commit();
    }

    private static BookQuantity? FindBookQuantity(Reservation reservation)
    {
        return reservation.Book.BookQuantities
            .FirstOrDefault(q => 
                q.BookId == reservation.BookId 
                && q.LibraryId == reservation.LibraryId);
    }
    
    public async Task ReturnBook(Guid reservationId)
    {
        var reservation = await Repository.FindById(reservationId);
        if (reservation == null)
        {
            throw new NotFoundException($"Reservation with id {reservationId} not found");
        }
        
        var bookQuantity = FindBookQuantity(reservation);
        if (bookQuantity == null)
        {
            throw new NotFoundException($"Book quantity for reservation {reservationId} not found");
        }
        
        reservation.ReturnDate = DateTime.Now;
        bookQuantity.Count += 1;

        var uow = UnitOfWorkFactory();
        await Repository.Update(reservation);
        await _bookQuantityRepository.Update(bookQuantity);
        await uow.Commit();
    }
    
    public IEnumerable<ReservationDto> FindAllForUser(string email)
    {
        var reviewQuery = new GetReservationHistoryQuery(Mapper, Query);
        return reviewQuery.Execute(new ReservationUserFilterDto { Email = email });
    }
}