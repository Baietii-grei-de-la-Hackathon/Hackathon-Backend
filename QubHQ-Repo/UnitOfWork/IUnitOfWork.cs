using Microsoft.EntityFrameworkCore.Storage;

namespace QubHq_Repo.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class;
    int Commit();
    Task<IDbContextTransaction> BeginTransactionAsync();
}