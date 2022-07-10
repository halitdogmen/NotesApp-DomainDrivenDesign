using NotesApp.Application.Contracts.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    /// <summary>
    /// Represents Admin Account in Notes Application
    /// </summary>
    public class AdminDTO:AccountDTO
    {
        /// <summary>
        /// Represents Admin nickname.
        /// </summary>
        public string NickName { get; set; }
    }
}
