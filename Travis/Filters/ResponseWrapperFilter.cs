using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Travis.Models;

namespace Travis.Filters
{
    public class ResponseWrapperFilter : IResultFilter
    {
        HttpContext _httpContext;
        public ResponseWrapperFilter(IHttpContextAccessor httpContextAccesssor)
        {
            _httpContext = httpContextAccesssor.HttpContext;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            //⚆_⚆  ¯\_(ツ)_/¯
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            string username = _httpContext.User?.Identity?.Name;

            var result = context.Result;
            if (result is ObjectResult objResult)
            {
                var newValue = new BaseResponseModel(username: username, true, errorMessages: null, statusCode: (HttpStatusCode)objResult.StatusCode, content: objResult.Value);

                context.Result = new ObjectResult(newValue)
                {
                    StatusCode = objResult.StatusCode
                };
            }
        }
    }
}
