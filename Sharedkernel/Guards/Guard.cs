using Sharedkernel.Exceptions;
using System;

namespace Sharedkernel.Guards
{
    public static class Guard
    {
        public static void AgainstNull(object obj, string message)
        {
            if (obj == null)
                throw new ArgumentNullException(message);
        }

        public static void AgainstEmptyString(string obj, string objName)
        {
            if (string.IsNullOrWhiteSpace(obj))
                throw new NullOrEmptyException($"{objName} cannot be empty");
        }

        public static void AgainstInvalidArgument(bool valid, string message)
        {
            if (!valid)
                throw new InvalidArgumentException(message);
        }
    }
}
