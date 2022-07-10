using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
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
    /// Represents Account Get All Specification. Encapsulates Linq queries. See more: specification pattern.
    /// </summary>
    public class AccountGetAllSpecification : Specification<Account>
    {
        public override Expression<Func<Account, bool>> ToExpression()
        {
            return account => account.IsDeleted == false;
        }
    }
}
