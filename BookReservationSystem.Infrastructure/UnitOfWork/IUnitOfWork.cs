namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IUnitOfWork: IDisposable
{
    Task CommitAsync();
    Task RollbackAsync();
}