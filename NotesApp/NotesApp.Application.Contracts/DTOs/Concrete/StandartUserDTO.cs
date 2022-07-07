using NotesApp.Application.Contracts.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    public class StandartUserDTO:AccountDTO
    {
        public string Name { get; private set; }
        public string Lastname { get; private set; }
    }
}
