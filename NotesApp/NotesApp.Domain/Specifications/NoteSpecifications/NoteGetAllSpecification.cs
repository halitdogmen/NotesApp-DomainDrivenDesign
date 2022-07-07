using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using SeedWork.Domain.Specifications.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Specifications.NoteSpecifications
{
    public class NoteGetAllSpecification : Specification<Note>
    {
        public override Expression<Func<Note, bool>> ToExpression()
        {
            return note => note.IsDeleted == false;
        }
    }
}
