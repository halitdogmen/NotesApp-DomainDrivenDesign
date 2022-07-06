using SeedWork.Domain.Models;
using SeedWork.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.Domain.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<List<T>> GetAsync(ISpecification<T> spec, int limit, int offset);
        Task<T?> GetOneAsync(ISpecification<T> spec);
        Task<bool> AnyAsync(ISpecification<T> spec);
        Task<long> CountAsync(ISpecification<T> spec);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
