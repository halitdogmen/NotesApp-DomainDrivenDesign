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
    public class StandartUser:Account
    {
        public string Name { get; private set; }
        public string Lastname { get; private set; }
        private StandartUser():base() {/* For EFCore */ }

        public StandartUser(string name,string lastname,Email email, byte[] passwordHash, byte[] passwordSalt):base(email,passwordHash,passwordSalt)
        {
            SetName(name);
            SetLastname(lastname);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new AttributeNotValidException($"{nameof(name)} can not be null or empty");
            Name = name;
        }

        public void SetLastname(string lastname)
        {
            if (string.IsNullOrEmpty(lastname)) throw new AttributeNotValidException($"{nameof(lastname)} can not be null or empty not");
            Lastname = lastname;
        }
    }
}
