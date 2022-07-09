using Microsoft.EntityFrameworkCore;
using SeedWork.Domain.Models;
using SeedWork.Domain.Repositories;
using SeedWork.Domain.Specifications.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.Infrastructure.Repositories
{
    public abstract class GenericRepository<TModel, TContext> : IRepository<TModel> where TModel : BaseModel where TContext : DbContext
    {
        private readonly TContext context;
        protected GenericRepository(TContext context)
        {
            this.context = context;
        }

        public async Task<bool> AnyAsync(ISpecification<TModel> spec)
        {
            return await context.Set<TModel>()
                .AnyAsync(spec.ToExpression());
        }

        public async Task<long> CountAsync(ISpecification<TModel> spec)
        {
            return await context.Set<TModel>()
                .CountAsync(spec.ToExpression());
        }

        public async Task CreateAsync(TModel entity)
        {
            await context.Set<TModel>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TModel entity)
        {
            context.Set<TModel>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public Task<List<TModel>> GetAsync(ISpecification<TModel> spec, int limit, int offset)
        {
            return context.Set<TModel>()
                .Where(spec.ToExpression())
                .OrderBy(e => e.CreatedAt)
                .Skip(offset)
                .Take(limit + offset)
                .ToListAsync();
        }

        public Task<TModel?> GetOneAsync(ISpecification<TModel> spec)
        {
            return context.Set<TModel>()
                .Where(spec.ToExpression())
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(TModel entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
