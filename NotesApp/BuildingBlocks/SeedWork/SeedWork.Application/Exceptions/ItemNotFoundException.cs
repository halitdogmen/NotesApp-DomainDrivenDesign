﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.Application.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() { }

        public ItemNotFoundException(string message) : base(message) { }

        public ItemNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
