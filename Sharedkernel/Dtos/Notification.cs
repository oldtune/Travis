using Sharedkernel.Guards;
using System.Collections.Generic;
using System.Linq;

namespace Sharedkernel
{
    public class Notification
    {
        private readonly List<Error> _listError = new List<Error>();

        public void AddError(Error error)
        {
            Guard.AgainstNull(error, "Cannot add null or empty Error");
            _listError.Add(error);
        }

        public bool HasError => _listError.Any();

        public IReadOnlyList<string> Errors => _listError.Select(e => e.Value).ToList().AsReadOnly();

        public class Error
        {
            public Error(string error)
            {
                Guard.AgainstEmptyString(error, "Notification error cannot be empty");
                Value = error;
            }
            public string Value { get; }
        }
    }
}
