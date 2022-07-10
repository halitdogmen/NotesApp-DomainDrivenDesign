using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
using SeedWork.Domain.Specifications.Abstract;
using SeedWork.Domain.Specifications.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Specifications.AccountSpecifications
{
    /// <summary>
    /// Represents Account Get By Id Specification. Encapsulates Linq queries. See more: Specification Pattern.
    /// </summary>
    public class AccountGetByIdSpecification : Specification<Account>, ICachedSpecification<Account>
    {
        public TimeSpan CacheDuration => new TimeSpan(0, 5, 0);
        private readonly Guid _id;
        /// <summary>
        /// Consructor
        /// </summary>
        /// <param name="id"> Represents Account Id.</param>
        public AccountGetByIdSpecification(Guid id)
        {
            _id = id;
        }

        public override Expression<Func<Account, bool>> ToExpression()
        {
            return account => account.Id.Equals(_id) && account.IsDeleted == false;
        }
        public string GetCacheKey()
        {
            return this.GetType().Name+_id;
        }
    }
}
