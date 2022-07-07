using SeedWork.Domain.Models;
using SeedWork.Domain.Specifications.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.Domain.Specifications.Concrete
{
    public abstract class Specification<T> : ISpecification<T> where T : BaseModel
    {
        public virtual bool IsSatisfiedBy(T obj)
        {
            return ToExpression().Compile()(obj);
        }

        public abstract Expression<Func<T, bool>> ToExpression();

        public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
        {
            return specification.ToExpression();
        }
    }
}
