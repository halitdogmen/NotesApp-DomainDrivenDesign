using NotesApp.Application.Contracts.DTOs.Abstract;
using SeedWork.Application.Utils.JWT.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    /// <summary>
    /// Represents Authentication Data Tranfer Object in Notes App
    /// </summary>
    public class AuthDTO
    {
        /// <summary>
        /// Represents Account Data Transfer Object
        /// </summary>
        public AccountDTO Account { get; set; }
        /// <summary>
        /// Represents Token Object.
        /// </summary>
        public AccessToken AccessToken { get; set; }
    }
}
