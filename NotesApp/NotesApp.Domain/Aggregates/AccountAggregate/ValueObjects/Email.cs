using SeedWork.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Aggregates.AccountAggregate.ValueObjects
{
    public record Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            if (!IsValid(value)) throw new AttributeNotValidException($"{nameof(Email)} is not valid");
            Value = value;
        }

        private bool IsValid(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
