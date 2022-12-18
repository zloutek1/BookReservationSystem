using AutoMapper;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.BL.Services;

public class GenreService: CrudService<Genre, GenreDto>, IGenreService
{
    public GenreService(IQuery<Genre> query, IRepository<Genre> repository, IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory) : base(query, repository, mapper, unitOfWorkFactory)
    {
    }
}