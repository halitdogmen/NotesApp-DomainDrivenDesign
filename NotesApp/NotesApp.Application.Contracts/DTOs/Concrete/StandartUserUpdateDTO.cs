﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Concrete
{
    public class StandartUserUpdateDTO
    {
        public string? Name { get; private set; }
        public string? Lastname { get; private set; }
    }
}