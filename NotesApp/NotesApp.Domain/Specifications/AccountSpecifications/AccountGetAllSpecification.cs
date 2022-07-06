using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
using SeedWork.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Specifications.AccountSpecifications
{
    public class AccountGetAllSpecification : Specification<Account>
    {
        public override Expression<Func<Account, bool>> ToExpression()
        {
            return account => account.IsDeleted == false;
        }
    }
}
