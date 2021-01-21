using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Travis.Models
{
    public class BaseResponseModel
    {
        public string CurrentUserName { get; }
        public DateTime ResponseAt { get; }
        public HttpStatusCode StatusCode { get; }
        public bool Success { get; }
        public string[] ErrorMessages { set; get; }
        public object Content { get; }

        public BaseResponseModel(string username, bool success, IEnumerable<string> errorMessages, HttpStatusCode statusCode, object content)
        {
            CurrentUserName = username;
            Success = success;
            ErrorMessages = ErrorMessages ?? Enumerable.Empty<string>().ToArray();
            StatusCode = statusCode;
            Content = content;
            ResponseAt = DateTime.UtcNow;
        }
    }
}
