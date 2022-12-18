using AutoMapper;
using BookReservationSystem.BL.Exceptions;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;

namespace BookReservationSystem.BL.Services;

public abstract class CrudService<TEntity, TDto>: ICrudService<TDto> where TEntity : class, new()
{
    protected readonly IMapper Mapper;
    protected readonly Func<IUnitOfWork> UnitOfWorkFactory;
    protected readonly IQuery<TEntity> Query;
    protected readonly IRepository<TEntity> Repository;

    protected CrudService(IQuery<TEntity> query, IRepository<TEntity> repository, IMapper mapper, Func<IUnitOfWork> unitOfWorkFactory)
    {
        Query = query;
        Repository = repository;
        Mapper = mapper;
        UnitOfWorkFactory = unitOfWorkFactory;
    }

    public async Task<IEnumerable<TDto>> FindAll()
    {
        var foundEntities = await Query.Page(1, 15).Execute();
        return Mapper.Map<IEnumerable<TDto>>(foundEntities);
    }

    public async Task<TDto?> FindById(Guid id)
    {
        var foundEntity = await Repository.FindById(id);
        return Mapper.Map<TDto?>(foundEntity);
    }

    public async Task Insert(TDto createDto)
    {
        var entity = Mapper.Map<TEntity>(createDto);
        await using var uow = UnitOfWorkFactory();
        try
        {
            await Repository.Insert(entity);
            await uow.Commit();
        }
        catch (Exception ex)
        {
            await uow.Rollback();
            throw new ServiceException("Could not insert entity", ex);
        }
    }

    public async Task Update(TDto updateDto)
    {
        var entity = Mapper.Map<TEntity>(updateDto);
        await using var uow = UnitOfWorkFactory();
        try
        {
            await Repository.Update(entity);
            await uow.Commit();
        }
        catch (Exception ex)
        {
            await uow.Rollback();
            throw new ServiceException("Could not update entity", ex);
        }
    }

    public async Task Delete(Guid id)
    {
        await using var uow = UnitOfWorkFactory();
        try
        {
            await Repository.Delete(id);
            await uow.Commit();
        }
        catch (Exception ex)
        {
            await uow.Rollback();
            throw new ServiceException("Could not delete entity", ex);
        }
    }
}