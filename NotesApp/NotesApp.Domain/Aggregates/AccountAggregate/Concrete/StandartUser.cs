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
    /// Represents Standart Account For Notes Application.
    /// </summary>
    public class StandartUser:Account
    {
        /// <summary>
        /// Represents Standart User Name.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Represents Standart User Lastname.
        /// </summary>
        public string Lastname { get; private set; }
        /// <summary>
        /// private contructor For EFCore.
        /// </summary>
        private StandartUser():base() {/* For EFCore */ }

        /// <summary>
        /// Standart User Consructor.
        /// </summary>
        /// <param name="name">Represents Standart User Name. Cannot be empty or null.</param>
        /// <param name="lastname">Represent standart User Lastname. Cannot be empty or null.</param>
        /// <param name="email">Represents Standart User Email. it must be valid.</param>
        /// <param name="passwordHash">Represents Standart User Password Hash. Cannot be empty or null.</param>
        /// <param name="passwordSalt">Represents Standart User Password Salt. Cannot be empty or null.</param>
        public StandartUser(string name,string lastname,Email email, byte[] passwordHash, byte[] passwordSalt):base(email,passwordHash,passwordSalt)
        {
            SetName(name);
            SetLastname(lastname);
        }
        /// <summary>
        /// Setter Function For Name Property.
        /// </summary>
        /// <param name="name"> Represents Standart User Name. Cannot be empty or null.</param>
        /// <exception cref="AttributeNotValidException"></exception>
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new AttributeNotValidException($"{nameof(name)} can not be null or empty");
            Name = name;
        }
        /// <summary>
        ///  Setter Function For Lastname Property.
        /// </summary>
        /// <param name="lastname">Represents Standart User Lastname. cannot be empty or null.</param>
        /// <exception cref="AttributeNotValidException"></exception>
        public void SetLastname(string lastname)
        {
            if (string.IsNullOrEmpty(lastname)) throw new AttributeNotValidException($"{nameof(lastname)} can not be null or empty not");
            Lastname = lastname;
        }
    }
}
