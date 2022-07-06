using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.Domain.Exceptions
{
    public class AttributeNotValidException:Exception
    {
        public AttributeNotValidException() { }

        public AttributeNotValidException(string message) : base(message) { }

        public AttributeNotValidException(string message, Exception inner):base(message, inner) { }
    }
}
