using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using SeedWork.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Repositories
{
    /// <summary>
    /// Represents Notes Application Notes Repository.
    /// </summary>
    public interface INoteRepository:IRepository<Note>
    {
    }
}
