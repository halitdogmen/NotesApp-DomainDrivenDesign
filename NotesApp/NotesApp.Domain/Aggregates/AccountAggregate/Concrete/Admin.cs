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
    /// <summary>
    /// Represents Notes Application Admin Account.
    /// </summary>
    public class Admin:Account
    {
        /// <summary>
        /// Represents Admin's nickname.
        /// </summary>
        public string NickName { get; private set; }
        /// <summary>
        ///  Consructor for EFCore
        /// </summary>
        private Admin() { /* For EfCore*/}
        /// <summary>
        /// Consructor For Admin Model.
        /// </summary>
        /// <param name="nickname"> Represents Admin's nickname. Cannot be empty or null.</param>
        /// <param name="email">Represents Admin's email. It must be valid.</param>
        /// <param name="passwordHash">Represents Admin's Password Hash. Cannot be empty or null.</param>
        /// <param name="passwordSalt">Represents Admin's Password Salt. Cannot be empty or null.</param>
        public Admin(string nickname,Email email, byte[] passwordHash, byte[] passwordSalt) : base(email, passwordHash, passwordSalt)
        {
            SetNickName(nickname);
        }
        /// <summary>
        ///  Setter For Admin's Nickname. Private use only.
        /// </summary>
        /// <param name="nickname">Admin's nickname. Cannot be empty or null</param>
        /// <exception cref="AttributeNotValidException"></exception>
        private void SetNickName(string nickname)
        {
            if (string.IsNullOrEmpty(nickname)) throw new AttributeNotValidException($"{nameof(nickname)} can not be null or empty");

            NickName = nickname;
        }
    }
}
