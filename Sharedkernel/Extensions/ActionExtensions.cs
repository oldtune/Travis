using Sharedkernel.F;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharedkernel.Extensions
{
    public static class ActionExtensions
    {
        public static Func<T, Unit> ToFunc<T>(this Action<T> action)
        =>
            (something) =>
            {
                action(something);
                return new Unit();
            };

        public static Func<Unit> ToFunc(this Action action)
        =>
            () =>
            {
                action();
                return new Unit();
            };
    }
}
