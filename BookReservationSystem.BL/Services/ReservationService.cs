using AutoMapper;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.BL.Query;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.BL.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly Func<IUnitOfWork> _unitOfWorkFactory;
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IQuery<Reservation> _reservationQuery;

        public ReservationService(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, IRepository<Reservation> reservationRespository, IQuery<Reservation> reservationQuery)
        {
            _mapper = mapper;
            _unitOfWorkFactory = unitOfWorkFactory;
            _reservationRepository = reservationRespository;
            _reservationQuery = reservationQuery;
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

        public IEnumerable<ReservationDto> FindAllForUser(string email)
        {
            var reviewQuery = new GetReservationHistoryQuery(_mapper, _reservationQuery);
            return reviewQuery.Execute(new ReservationUserFilterDto() { Email = email });
        }
    }
}
