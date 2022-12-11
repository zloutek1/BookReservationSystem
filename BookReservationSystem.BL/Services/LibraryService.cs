using AutoMapper;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.BL.Services;

public class LibraryService: ICrudService<LibraryDto>
{
    private readonly IMapper _mapper;
    private readonly Func<IUnitOfWork> _unitOfWorkFactory;
    private readonly IRepository<Library> _libraryRepository;
    
    public LibraryService(IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory, IRepository<Library> libraryRepository)
    {
        _mapper = mapper;
        _unitOfWorkFactory = unitOfWorkFactory;
        _libraryRepository = libraryRepository;
    }
    
    public IEnumerable<LibraryDto> FindAll()
    {
        var foundLibraries = _libraryRepository.FindAll();
        return _mapper.Map<IEnumerable<LibraryDto>>(foundLibraries);
    }

    public LibraryDto? FindById(Guid id)
    {
        var foundLibrary = _libraryRepository.FindById(id);
        return _mapper.Map<LibraryDto?>(foundLibrary);
    }

    public void Insert(LibraryDto libraryDto)
    {
        var library = _mapper.Map<Library>(libraryDto);
        using var uow = _unitOfWorkFactory();
        _libraryRepository.Insert(library);
        uow.Commit();
    }

    public void Update(LibraryDto libraryDto)
    {
        var library = _mapper.Map<Library>(libraryDto);
        using var uow = _unitOfWorkFactory();
        _libraryRepository.Update(library);
        uow.Commit();
    }

    public void Delete(Guid id)
    {
        using var uow = _unitOfWorkFactory();
        _libraryRepository.Delete(id);
        uow.Commit();
    }
}