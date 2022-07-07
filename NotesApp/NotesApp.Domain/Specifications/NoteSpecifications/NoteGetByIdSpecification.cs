using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using SeedWork.Domain.Specifications.Abstract;
using SeedWork.Domain.Specifications.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Specifications.NoteSpecifications
{
    public class NoteGetByIdSpecification : Specification<Note>, ICachedSpecification<Note>
    {
        public TimeSpan CacheDuration => new TimeSpan(0, 5, 0);
        private readonly Guid _id;

        public NoteGetByIdSpecification(Guid id)
        {
            _id = id;
        }
        public override Expression<Func<Note, bool>> ToExpression()
        {
            return note => note.Id.Equals(_id) && note.IsDeleted == false;
        }
        public string GetCacheKey()
        {
           return this.GetType().Name+_id;
        }
    }
}
