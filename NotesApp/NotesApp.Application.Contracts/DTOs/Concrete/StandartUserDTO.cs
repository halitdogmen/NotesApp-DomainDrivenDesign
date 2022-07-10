using NotesApp.Application.Contracts.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    /// <summary>
    /// Represents Standart User Data Transfer Object.
    /// </summary>
    public class StandartUserDTO:AccountDTO
    {
        /// <summary>
        /// Standart User Name.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Standart User Lastname.
        /// </summary>
        public string Lastname { get; private set; }
    }
}
