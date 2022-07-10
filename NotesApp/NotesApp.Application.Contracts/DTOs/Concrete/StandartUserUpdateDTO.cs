using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    /// <summary>
    /// Represents Standart User Update Data Transfer Object. It is used For updating Standart User.
    /// </summary>
    public class StandartUserUpdateDTO
    {
        /// <summary>
        /// Represents Standart User Name.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Represents Standart User Lastname.
        /// </summary>
        public string? Lastname { get; set; }
    }
}
