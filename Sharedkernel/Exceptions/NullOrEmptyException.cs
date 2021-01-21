using System;

namespace Sharedkernel.Exceptions
{
    public class NullOrEmptyException : Exception
    {
        public NullOrEmptyException(string message) : base(message)
        {

        }
    }
}
