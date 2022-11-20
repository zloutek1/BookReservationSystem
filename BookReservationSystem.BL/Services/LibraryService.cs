using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.BL.Services;

public class LibraryService: ICrudService<LibraryDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Library> _libraryRepository;
    
    public LibraryService(IMapper mapper, IUnitOfWork unitOfWork, IRepository<Library> libraryRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
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
        _libraryRepository.Insert(library);
    }

    public void Update(LibraryDto libraryDto)
    {
        var library = _mapper.Map<Library>(libraryDto);
        _libraryRepository.Update(library);
    }

    public void Delete(Guid id)
    {
        _libraryRepository.Delete(id);
    }
}