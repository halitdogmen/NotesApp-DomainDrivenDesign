using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using NotesApp.Domain.Repositories;
using NotesApp.Infrastructure.Database;
using SeedWork.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Infrastructure.Repositories
{
    public class NoteRepository : GenericRepository<Note, DatabaseContext>, INoteRepository
    {
        public NoteRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
