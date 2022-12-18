using AutoMapper;
using BookReservationSystem.BL.Exceptions;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.BL.Services;

public class BookQuantityService: IBookQuantityService
{
    private readonly IMapper _mapper;
    private readonly Func<IUnitOfWork> _unitOfWorkFactory;
    private readonly IQuery<BookQuantity> _query;
    private readonly IRepository<BookQuantity> _repository;
    
    public BookQuantityService(IQuery<BookQuantity> query, IRepository<BookQuantity> repository, IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory)
    {
        _query = query;
        _repository = repository;
        _mapper = mapper;
        _unitOfWorkFactory = unitOfWorkFactory;
    }
    
    public async Task<BookQuantityDto?> FindById(Guid libraryId, Guid bookId)
    {
        var record = (await _query
                .Where(q => q.LibraryId == libraryId && q.BookId == bookId)
                .Execute())
            .FirstOrDefault();
        
        return _mapper.Map<BookQuantityDto?>(record);
    }
    
    public async Task Insert(BookQuantityCreateDto createDto)
    {
        var entity = _mapper.Map<BookQuantity>(createDto);
        await using var uow = _unitOfWorkFactory();
        try
        {
            await _repository.Insert(entity);
            await uow.Commit();
        } 
        catch (Exception ex)
        {
            await uow.Rollback();
            throw new ServiceException("Could not insert record", ex);
        }
    }
    
    public async Task Update(BookQuantityCreateDto updateDto)
    {
        var entity = _mapper.Map<BookQuantity>(updateDto);
        await using var uow = _unitOfWorkFactory();
        try
        {
            await _repository.Update(entity);
            await uow.Commit();
        }
        catch (Exception ex)
        {
            await uow.Rollback();
            throw new ServiceException("Could not update record", ex);
        }
    }

    public async Task Delete(Guid libraryId, Guid bookId)
    {
        var record = (await _query
            .Where(q => q.LibraryId == libraryId && q.BookId == bookId)
            .Execute())
            .FirstOrDefault();
        
        if (record == null)
        {
            throw new NotFoundException($"Record for book with id: {bookId} in library with id: {libraryId} not found");
        }
        
        await using var uow = _unitOfWorkFactory();
        try
        {
            await _repository.Delete(record!);
            await uow.Commit();
        }
        catch (Exception ex)
        {
            await uow.Rollback();
            throw new ServiceException("Could not delete record", ex);
        }
    }
}