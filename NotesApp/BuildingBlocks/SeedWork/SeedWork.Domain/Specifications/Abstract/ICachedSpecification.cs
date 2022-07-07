using SeedWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.Domain.Specifications.Abstract
{
    public interface ICachedSpecification<T>:ISpecification<T> where T : BaseModel
    {
        string GetCacheKey();
        /// <summary>
        /// The cache duration
        /// </summary>
        TimeSpan CacheDuration { get; }
    }
}
