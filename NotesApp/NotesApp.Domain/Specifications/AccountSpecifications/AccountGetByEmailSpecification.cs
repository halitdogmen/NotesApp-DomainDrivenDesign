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
    public class AccountGetByEmailSpecification : Specification<Account>, ICachedSpecification<Account>
    {
        public TimeSpan CacheDuration => new TimeSpan(0, 5, 0);
        private readonly string _email;

        public AccountGetByEmailSpecification(string email)
        {
            _email = email;
        }
        public override Expression<Func<Account, bool>> ToExpression()
        {
            return account => account.Email.Value.Equals(_email) && account.IsDeleted == false;
        }
        

        public string GetCacheKey()
        {
            return this.GetType().Name + _email;
        }

    }
}
