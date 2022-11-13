using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.BL.Services;

public class LibraryService: ICrudService<LibraryDto>
{
    private readonly IMapper _mapper;
    private readonly ILibraryUnitOfWork _libraryUnitOfWork;
    
    public LibraryService(IMapper mapper, ILibraryUnitOfWork libraryUnitOfWork)
    {
        _mapper = mapper;
        _libraryUnitOfWork = libraryUnitOfWork;
    }
    
    public IEnumerable<LibraryDto> FindAll()
    {
        var foundLibraries = _libraryUnitOfWork.LibraryRepository.FindAll();
        return _mapper.Map<IEnumerable<LibraryDto>>(foundLibraries);
    }

    public LibraryDto? FindById(Guid id)
    {
        var foundLibrary = _libraryUnitOfWork.LibraryRepository.FindById(id);
        return _mapper.Map<LibraryDto?>(foundLibrary);
    }

    public void Insert(LibraryDto libraryDto)
    {
        var library = _mapper.Map<Library>(libraryDto);
        _libraryUnitOfWork.LibraryRepository.Insert(library);
    }

    public void Update(LibraryDto libraryDto)
    {
        var library = _mapper.Map<Library>(libraryDto);
        _libraryUnitOfWork.LibraryRepository.Update(library);
    }

    public void Delete(Guid id)
    {
        _libraryUnitOfWork.LibraryRepository.Delete(id);
    }
}