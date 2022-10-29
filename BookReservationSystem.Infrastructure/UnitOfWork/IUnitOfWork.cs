namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IUnitOfWork: IDisposable
{
    Task Commit();
    Task Rollback();
}