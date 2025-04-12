using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace QubHq_Repo.UnitOfWork;

 public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly QubHQDbContext context;
        private readonly DbSet<T> dbSet;
        
        public Repository(QubHQDbContext context)
        {
            this.context = context;

            this.dbSet = context.Set<T>();
        }

        public virtual EntityState Add(T entity)
        {
            return this.dbSet.Add(entity).State;
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await this.dbSet.AddRangeAsync(entities);
        }

        public virtual async Task<EntityState> AddAsync(T entity)
        {
            return (await this.dbSet.AddAsync(entity)).State;
        }

        public T Get<TKey>(TKey id)
        {
            return this.dbSet.Find(id);
        }

        public async Task<T> GetAsync<TKey>(TKey id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public T Get(params object[] keyValues)
        {
            return this.dbSet.Find(keyValues);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include)
        {
            return this.FindBy(predicate).Include(include);
        }

        public IQueryable<T> GetAll()
        {
            return this.dbSet;
        }

        public IQueryable<T> GetAll(int page, int pageCount)
        {
            var pageSize = (page - 1) * pageCount;

            return this.dbSet.Skip(pageSize).Take(pageCount);
        }

        public IQueryable<T> GetAll(string include)
        {
            return this.dbSet.Include(include);
        }

        public IQueryable<T> FromSqlRaw(string query, params object[] parameters)
        {
            return this.dbSet.FromSqlRaw(query, parameters);
        }

        public IQueryable<T> GetAll(string[] includes)
        {
            IQueryable<T> result = this.dbSet.AsQueryable();

            foreach (var include in includes)
            {
                result = result.Include(include);
            }

            return result;
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Any(predicate);
        }

        public EntityState Delete(T entity)
        {
            return this.dbSet.Remove(entity).State;
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            this.dbSet.RemoveRange(entities);
        }

        public virtual EntityState Update(T entity)
        {
            return this.dbSet.Update(entity).State;
        }
    }