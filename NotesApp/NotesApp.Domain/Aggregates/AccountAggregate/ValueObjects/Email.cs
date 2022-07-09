using SeedWork.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Domain.Aggregates.AccountAggregate.ValueObjects
{
    /// <summary>
    ///  Represents Notes Application Account's Email.
    /// </summary>
    public record Email
    {
        /// <summary>
        /// Represents Email Value
        /// </summary>
        public string Value { get; private set; }
        /// <summary>
        /// Constructor For Email Value Object
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="AttributeNotValidException"></exception>
        public Email(string value)
        {
            if (!IsValid(value)) throw new AttributeNotValidException($"{nameof(Email)} is not valid");
            Value = value;
        }
        /// <summary>
        ///  Checks validation 
        /// </summary>
        /// <param name="email">Email For Validation</param>
        /// <returns></returns>
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
