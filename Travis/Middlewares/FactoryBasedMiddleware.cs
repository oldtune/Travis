using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travis.Middlewares
{
    //IMiddleware stuff
    //  https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/extensibility?view=aspnetcore-5.0
    public static class MiddlewareExtensions
    {
        //public static IApplicationBuilder UseConventionalMiddleware(
        //    this IApplicationBuilder builder)
        //{
        //    return builder.UseMiddleware<ResponseTransformMiddleware>();
        //}

        public static IApplicationBuilder UseFactoryActivatedMiddleware(
            this IApplicationBuilder builder)
        {
            builder.UseMiddleware<LoggingContextMiddleware>();
            //builder.UseMiddleware<ResponseWrapperMiddleware>();

            return builder;
        }
    }
}
