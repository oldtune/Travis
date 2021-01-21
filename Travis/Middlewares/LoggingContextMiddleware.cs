using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Travis.Middlewares
{
    //Log request & response
    public class LoggingContextMiddleware : IMiddleware
    {
        readonly ILogger<LoggingContextMiddleware> _logger;
        public LoggingContextMiddleware(ILogger<LoggingContextMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Request.EnableBuffering();
            string requestContent = await FormatRequest(context.Request);
            string responseContent;

            Stream originalBody = context.Response.Body;

            try
            {
                using (var memStream = new MemoryStream())
                {
                    context.Response.Body = memStream;

                    await next(context);

                    memStream.Position = 0;
                    string responseBody = new StreamReader(memStream).ReadToEnd();

                    memStream.Position = 0;
                    await memStream.CopyToAsync(originalBody);

                    responseContent = $"{context.Response.StatusCode}: {responseBody}";
                }

            }
            finally
            {
                context.Response.Body = originalBody;
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();

            request.Body.Position = 0;

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            await request.Body.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);

            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body.Position = 0;

            return
                $"{request.Scheme}" +
                $"{Environment.NewLine}" +
                $" {request.Host}" +
                $"{Environment.NewLine}" +
                $"{request.Path}" +
                $"{Environment.NewLine}" +
                $" {request.QueryString}" +
                $"{Environment.NewLine}" +
                $" {bodyAsText}";
        }
    }
}
