using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Data.Exceptions
{
    [Serializable]
    public class DuplicatedIdException : Exception
    {
        public DuplicatedIdException()
        {
        }

        public DuplicatedIdException(string? message) : base(message)
        {
        }

        public DuplicatedIdException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DuplicatedIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
