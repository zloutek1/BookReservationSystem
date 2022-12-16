using AutoMapper;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.BL.Services;

public class LibraryService: CrudService<Library, LibraryDto>
{
    public LibraryService(IQuery<Library> query, IRepository<Library> repository, IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory) : base(query, repository, mapper, unitOfWorkFactory)
    {
    }
}