using Domain.Base;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(EFContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(true);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefaultAsync(expression);
        }

        public Task<List<T>> ListAsync(Expression<Func<T, bool>> expression, int page = 0, int size = 100, string includeExpression = "")
        {
            var result = _dbSet.Where(expression);

            if (!string.IsNullOrEmpty(includeExpression))
            {
                var includes = includeExpression.Split(';');
                foreach (string include in includes)
                {
                    if (!string.IsNullOrEmpty(include))
                        result = result.Include(include);
                }
            }

            if (size < 1)
                size = 10;

            if (page < 0)
                page = 0;

            result = result == null ? null : result.Skip(page * size).Take(size);
            return result == null ? null : result.ToListAsync();
        }

        public Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
