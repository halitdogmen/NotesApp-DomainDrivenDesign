using SeedWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.Domain.Specifications.Abstract
{
    public interface ISpecification<T> where T : BaseModel
    {
        bool IsSatisfiedBy(T obj);
        Expression<Func<T, bool>> ToExpression();
    }
}
