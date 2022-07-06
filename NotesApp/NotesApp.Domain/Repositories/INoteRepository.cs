using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using SeedWork.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Repositories
{
    public interface INoteRepository:IRepository<Note>
    {
    }
}
