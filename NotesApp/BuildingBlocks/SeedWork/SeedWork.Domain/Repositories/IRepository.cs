using SeedWork.Domain.Models;
using SeedWork.Domain.Specifications.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.Domain.Repositories
{
    /// <summary>
    /// Represents Basic Data Access Operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : BaseModel
    {
        /// <summary>
        /// Gets Limits object from offset. sorted objects creation time.
        /// </summary>
        /// <param name="spec">Object Specification</param>
        /// <param name="limit">How Many.</param>
        /// <param name="offset">Where from.</param>
        /// <returns></returns>
        Task<List<T>> GetAsync(ISpecification<T> spec, int limit, int offset);
        /// <summary>
        /// Get One Object
        /// </summary>
        /// <param name="spec">Object Specification</param>
        /// <returns></returns>
        Task<T?> GetOneAsync(ISpecification<T> spec);
        /// <summary>
        /// Checks if exists.
        /// </summary>
        /// <param name="spec">Object Specification.</param>
        /// <returns></returns>
        Task<bool> AnyAsync(ISpecification<T> spec);
        /// <summary>
        /// Count Objects.
        /// </summary>
        /// <param name="spec">Object Specification.</param>
        /// <returns></returns>
        Task<long> CountAsync(ISpecification<T> spec);
        /// <summary>
        /// Creates Object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateAsync(T entity);
        /// <summary>
        /// Modifies Object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);
        /// <summary>
        /// Removes Object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);
    }
}
