using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.Application.Exceptions
{
    public class WrongAttemptException:Exception
    {
        public WrongAttemptException() { }

        public WrongAttemptException(string message) : base(message) { }

        public WrongAttemptException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
