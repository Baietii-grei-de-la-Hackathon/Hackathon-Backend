using Microsoft.EntityFrameworkCore.Storage;

namespace QubHq_Repo.UnitOfWork;
 public sealed class UnitOfWork : IUnitOfWork
    {
        private QubHQDbContext dbContext;
        private Dictionary<Type, object> repositories;

        public UnitOfWork(QubHQDbContext context)
        {
            dbContext = context;
        }
        
        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<TEntity>(dbContext);
            }

            return (IRepository<TEntity>)repositories[type];
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await dbContext.Database.BeginTransactionAsync();
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(obj: this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                    dbContext = null;
                }
            }
        }
    }