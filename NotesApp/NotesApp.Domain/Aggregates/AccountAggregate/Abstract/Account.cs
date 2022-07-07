using NotesApp.Domain.Aggregates.AccountAggregate.ValueObjects;
using SeedWork.Domain.Exceptions;
using SeedWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Aggregates.AccountAggregate.Abstracts
{
    public class Account:BaseModel
    {
        public Email Email { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

        protected Account(Email email, byte[] passwordHash, byte[] passwordSalt)
        {
            SetEmail(email);
            SetPassword(passwordHash, passwordSalt);
        }
        protected Account() { }

        public void SetPassword(byte[] passwordHash, byte[] passwordSalt)
        {
            if (passwordHash.Length == 0 || passwordHash is null) throw new AttributeNotValidException(nameof(passwordHash));
            PasswordHash = passwordHash;

            if (passwordSalt.Length == 0 || passwordSalt is null) throw new AttributeNotValidException(nameof(passwordHash));
            PasswordSalt = passwordSalt;
        }

        private void SetEmail(Email email)
        {
            if (email is null) throw new AttributeNotValidException(nameof(email));
            Email = email;
        }
    }
}
