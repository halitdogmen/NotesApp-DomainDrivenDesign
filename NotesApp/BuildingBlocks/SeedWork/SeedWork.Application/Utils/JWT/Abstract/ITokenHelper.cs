using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
using SeedWork.Application.Utils.JWT.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.Application.Utils.JWT.Abstract
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Account account);
    }
}
