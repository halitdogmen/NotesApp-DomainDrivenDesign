using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Abstract
{
    public class AccountDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        // optinal
        public string Type { get; set; }
    }
}
