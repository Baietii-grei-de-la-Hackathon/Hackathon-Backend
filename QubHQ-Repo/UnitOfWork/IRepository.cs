using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace QubHq_Repo.UnitOfWork;

public interface IRepository<T>
{
    T Get<TKey>(TKey id);
    Task<T> GetAsync<TKey>(TKey id);
    T Get(params object[] keyValues);
    IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include);
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(string include);
    IQueryable<T> GetAll(string[] includes);
    EntityState Add(T entity);
    Task<EntityState> AddAsync(T entity);
    EntityState Delete(T entity);
    bool Exists(Expression<Func<T, bool>> predicate);
    Task AddRangeAsync(IEnumerable<T> entities);
    void DeleteRange(IEnumerable<T> entities);
    EntityState Update(T entity);
}