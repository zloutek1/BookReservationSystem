namespace BookReservationSystem.Infrastructure.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> FindById(Guid id);
    Task Insert(TEntity obj);
    Task Update(TEntity obj);
    Task Delete(Guid id);
    Task Delete(TEntity obj);
    Task Commit();
}