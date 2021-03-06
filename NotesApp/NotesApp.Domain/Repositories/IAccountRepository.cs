using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
using SeedWork.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Repositories
{
    /// <summary>
    /// Represents Notes Application Accounts Repository.
    /// </summary>
    public interface IAccountRepository:IRepository<Account>
    {
    }
}
