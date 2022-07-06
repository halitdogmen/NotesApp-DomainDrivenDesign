using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using SeedWork.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Specifications.NoteSpecifications
{
    public class NoteGetByAccountIdSpecification : Specification<Note>
    {
        public readonly Guid accountId;

        public NoteGetByAccountIdSpecification(Guid accountId)
        {
            this.accountId = accountId;
        }

        public override Expression<Func<Note, bool>> ToExpression()
        {
            return note => note.AccountId.Equals(accountId) && note.IsDeleted == false;
        }
    }
}
