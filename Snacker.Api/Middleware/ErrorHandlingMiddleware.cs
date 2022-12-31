using System.Security.AccessControl;
using System.Threading;
using System.Net;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Api.Middleware;

    public class ErrorHandlingMiddleware : System.Exception
    {
        private readonly RequestDelegate _next

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContent context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception )
        {
            var code = HttpStatusCode.InternalServerError; //ErrorCode 500
            var result = JsonSerializer.SerializeObject(new {error = "An error occured while processing your request" });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            context.Response.WriteAsync(result);
        }

        [System.Serializable]
        public class ErrorHandlingMiddlewareException : System.Exception
        {
            public ErrorHandlingMiddlewareException() { }
            public ErrorHandlingMiddlewareException(string message) : base(message) { }
            public ErrorHandlingMiddlewareException(string message, System.Exception inner) : base(message, inner) { }
            protected ErrorHandlingMiddlewareException(
                System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
