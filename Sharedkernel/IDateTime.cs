using System;

namespace Sharedkernel
{
    public interface IDateTime
    {
        DateTime Now();
        DateTime UtcNow();
    }

    public class DefaultDateTime : IDateTime
    {
        public DateTime Now() => DateTime.Now;

        public DateTime UtcNow() => DateTime.UtcNow;
    }
}
