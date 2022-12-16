using AutoMapper;
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

    #region crud
    public IEnumerable<ReservationDto> FindAll()
    {
        var foundReservations = _reservationRepository.FindAll();
        return _mapper.Map<IEnumerable<ReservationDto>>(foundReservations);
    }

    public ReservationDto? FindById(Guid id)
    {
        var foundReservation = _reservationRepository.FindById(id);
        return _mapper.Map<ReservationDto?>(foundReservation);
    }

    public void Insert(ReservationDto reservationDto)
    {
        var reservation = _mapper.Map<Reservation>(reservationDto);
        using var uow = _unitOfWorkFactory();
        _reservationRepository.Insert(reservation);
        uow.Commit();
    }

    public void Update(ReservationDto reservationDto)
    {
        var reservation = _mapper.Map<Reservation>(reservationDto);
        using var uow = _unitOfWorkFactory();
        _reservationRepository.Update(reservation);
        uow.Commit();
    }

    public void Delete(Guid id)
    {
        using var uow = _unitOfWorkFactory();
        _reservationRepository.Delete(id);
        uow.Commit();
    }
    #endregion

    public void Insert(ReservationCreateDto createDto)
    {
        var reservation = _mapper.Map<Reservation>(createDto);
        
        var user = _userQuery.Where<string>(n => n == createDto.CustomerName, "UserName").Execute().FirstOrDefault();
        reservation.CustomerId = user!.Id; // TODO: handle error

        using var uow = _unitOfWorkFactory();
        _reservationRepository.Insert(reservation);
        _reservationRepository.Commit();
        uow.Commit();
    }

    public IEnumerable<ReservationDto> FindAllForUser(string email)
    {
        var reviewQuery = new GetReservationHistoryQuery(_mapper, _reservationQuery);
        return reviewQuery.Execute(new ReservationUserFilterDto() { Email = email });
    }
}