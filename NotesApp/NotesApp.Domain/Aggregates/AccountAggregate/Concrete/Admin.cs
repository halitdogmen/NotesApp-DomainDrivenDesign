using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
using NotesApp.Domain.Aggregates.AccountAggregate.ValueObjects;
using SeedWork.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Aggregates.AccountAggregate.Concrete
{
    public class Admin:Account
    {
        public string NickName { get; private set; }

        private Admin() { /* For EfCore*/}
        public Admin(string nickname,Email email, byte[] passwordHash, byte[] passwordSalt) : base(email, passwordHash, passwordSalt)
        {
            SetNickName(nickname);
        }

        private void SetNickName(string nickname)
        {
            if (string.IsNullOrEmpty(nickname)) throw new AttributeNotValidException($"{nameof(nickname)} can not be null or empty");

            NickName = nickname;
        }
    }
}
