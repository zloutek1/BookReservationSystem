namespace BookReservationSystem.Infrastructure.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> FindAll();
    TEntity? FindById(Guid id);
    void Insert(TEntity obj);
    void Update(TEntity obj);
    void Delete(Guid id);
    void Delete(TEntity obj);
    void Commit();
}