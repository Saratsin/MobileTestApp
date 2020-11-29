using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MobileTestApp.Repositories.Abstract
{
    public interface IRepository<TEntity> where TEntity : new()
    {
        Task<TEntity> GetAsync(object primaryKey);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveAsync(TEntity entity);

        Task<int> DeleteAsync(TEntity entity);

        Task<int> DeleteAsync(object primaryKey);

        Task<int> ExecuteAsync(string query, params object[] args);

        Task<List<TViewEntity>> QueryAsync<TViewEntity>(string query, params object[] args) where TViewEntity : new();
    }
}