using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    /// <summary>
    /// Represent Standart User Register Data Transfer Object. It is used for registiration for StandartUser.
    /// </summary>
    public class StandartUserRegisterDTO
    {
        /// <summary>
        /// Represents Standart User Name. Cannot be empty or null.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Represents Standart User Lastname. Cannot be empty or null.
        /// </summary>
        public string Lastname { get; set; }
        /// <summary>
        /// Represents Standart User Email. It must be valid. Ex:john.doe@example.com
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Represents Standart User Password. Cannot be empty or null. No other constraint. 
        /// </summary>
        public string Password { get; set; }
    }
}
