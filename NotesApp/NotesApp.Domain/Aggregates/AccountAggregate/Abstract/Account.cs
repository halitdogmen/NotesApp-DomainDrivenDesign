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
    /// <summary>
    /// Represents Notes Application Base Account(User).
    /// </summary>
    public class Account:BaseModel
    {
        /// <summary>
        /// Represents App user email.
        /// </summary>
        public Email Email { get; private set; }
        /// <summary>
        /// Represents App User Password Hash.
        /// </summary>
        public byte[] PasswordHash { get; private set; }
        /// <summary>
        /// represents App User Password Salt
        /// </summary>
        public byte[] PasswordSalt { get; private set; }

        /// <summary>
        /// Base App User Consructor
        /// </summary>
        /// <param name="email">Represents App User Email. Must be valid email</param>
        /// <param name="passwordHash">Represents App User Password Hash. Cannot be empty or null</param>
        /// <param name="passwordSalt">Represents App User Password Salt. Cannot be empty or null</param>
        protected Account(Email email, byte[] passwordHash, byte[] passwordSalt)
        {
            SetEmail(email);
            SetPassword(passwordHash, passwordSalt);
        }
        protected Account() { }
        /// <summary>
        /// Setter Function For Pasword Hash and Salt. Cannot be null or empty.
        /// </summary>
        /// <param name="passwordHash">Represents App User Password Hash. Cannot be empty or null.</param>
        /// <param name="passwordSalt">Represents App User Password Salt. Cannot be empty ore null.</param>
        /// <exception cref="AttributeNotValidException"></exception>
        public void SetPassword(byte[] passwordHash, byte[] passwordSalt)
        {
            if (passwordHash.Length == 0 || passwordHash is null) throw new AttributeNotValidException($"{nameof(passwordHash)} can not be null or empty");
            PasswordHash = passwordHash;

            if (passwordSalt.Length == 0 || passwordSalt is null) throw new AttributeNotValidException($"{nameof(passwordHash)} can not be null or empty");
            PasswordSalt = passwordSalt;
        }
        /// <summary>
        /// Setter Function for Email. This app scenerio, doesn't required in public.
        /// </summary>
        /// <param name="email">Represents App User Email.</param>
        /// <exception cref="AttributeNotValidException"></exception>
        private void SetEmail(Email email)
        {
            if (email is null) throw new AttributeNotValidException($"{nameof(email)} can not be null or empty");
            Email = email;
        }
    }
}
