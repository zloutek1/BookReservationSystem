namespace BookReservationSystem.Infrastructure.UnitOfWork;

public interface IUnitOfWork: IDisposable, IAsyncDisposable
{
    Task CommitAsync();
    Task RollbackAsync();
}