using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MobileTestApp.Repositories.Abstract
{
    public abstract class BaseRepository<TEntity> : BaseRepository, IRepository<TEntity> where TEntity : new()
    {
        protected override async ValueTask<SQLiteAsyncConnection> GetConnectionAsync()
        {
            var connection = await base.GetConnectionAsync().ConfigureAwait(false);
            if (!connection.TableMappings.Any(mapping => mapping.MappedType == typeof(TEntity)))
            {
                await connection.CreateTableAsync<TEntity>().ConfigureAwait(false);
            }
            
            return connection;
        }

        public virtual async Task<TEntity> GetAsync(object primaryKey)
        {
            var connection = await GetConnectionAsync().ConfigureAwait(false);
            var entity = await connection.GetAsync<TEntity>(primaryKey).ConfigureAwait(false);
            return entity;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var connection = await GetConnectionAsync().ConfigureAwait(false);
            var entity = await connection.GetAsync(predicate).ConfigureAwait(false);
            return entity;
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var connection = await GetConnectionAsync().ConfigureAwait(false);
            var entities = await connection.Table<TEntity>().Where(predicate).ToListAsync().ConfigureAwait(false);
            return entities;
        }

        public virtual async Task<int> SaveAsync(TEntity entity)
        {
            var connection = await GetConnectionAsync().ConfigureAwait(false);
            var result = await connection.InsertOrReplaceAsync(entity).ConfigureAwait(false);
            return result;
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            var connection = await GetConnectionAsync().ConfigureAwait(false);
            var result = await connection.DeleteAsync(entity).ConfigureAwait(false);
            return result;
        }

        public virtual async Task<int> DeleteAsync(object primaryKey)
        {
            var connection = await GetConnectionAsync().ConfigureAwait(false);
            var result = await connection.DeleteAsync<TEntity>(primaryKey).ConfigureAwait(false);
            return result;
        }

        public virtual async Task<int> ExecuteAsync(string query, params object[] args)
        {
            var connection = await GetConnectionAsync().ConfigureAwait(false);
            var result = await connection.ExecuteAsync(query, args).ConfigureAwait(false);
            return result;
        }

        public virtual async Task<List<TViewEntity>> QueryAsync<TViewEntity>(string query, params object[] args) where TViewEntity : new()
        {
            var connection = await GetConnectionAsync().ConfigureAwait(false);
            var viewEntities = await connection.QueryAsync<TViewEntity>(query, args).ConfigureAwait(false);
            return viewEntities;
        }
    }
}