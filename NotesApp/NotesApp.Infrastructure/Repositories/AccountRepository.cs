using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
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
    internal class AccountRepository : GenericRepository<Account, DatabaseContext>, IAccountRepository
    {
        public AccountRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
