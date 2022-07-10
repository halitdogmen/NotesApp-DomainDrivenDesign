using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    /// <summary>
    /// Represents Login Data Transfer Object. It is used for login.
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// Represents Account Email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Represents Account Password.
        /// </summary>
        public string Password { get; set; }
    }
}
