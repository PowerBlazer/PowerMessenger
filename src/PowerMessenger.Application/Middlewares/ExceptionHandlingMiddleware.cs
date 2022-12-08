using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PowerMessenger.Core.DTO;
using System.Net;

namespace PowerMessenger.Core.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message,
                    HttpStatusCode.InternalServerError, "Ошибка на сервере");
            }
            
        }

        private async Task HandleExceptionAsync(HttpContext httpContext , string exMessage,
            HttpStatusCode httpStatusCode,string message)
        {
            _logger.LogError(exMessage);

            HttpResponse response = httpContext.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorDTO errorDTO = new()
            {
                Message = message,
                StatusCode = (int)httpStatusCode
            };

            string result = errorDTO.ToString();

            await response.WriteAsync(result);
        }
    }
}
