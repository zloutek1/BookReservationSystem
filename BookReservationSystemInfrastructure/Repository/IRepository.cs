namespace BookReservationSystemInfrastructure.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(object id);
    void Insert(TEntity obj);
    void Update(TEntity obj);
    void Delete(object id);
    public Task Commit();
}