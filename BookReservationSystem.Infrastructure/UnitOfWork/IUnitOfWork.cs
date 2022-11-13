namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IUnitOfWork: IDisposable, IAsyncDisposable
{
    Task Commit();
    Task Rollback();
}