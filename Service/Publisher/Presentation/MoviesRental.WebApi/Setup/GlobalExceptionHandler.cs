using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.SqlClient;
using MoveisRental.Core.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace MoviesRental.WebApi.Setup
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            this.logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            (int statusCode, string errorMessage) = exception switch
            {
                ArgumentNullException ex => (500, ex.Message),
                DomainException ex => (500, ex.Message),
                SqlException ex => (500, ex.Message),
                ValidationException ex => (500, ex.Message),
                _ => (500, "Something went wrong")
            };

            logger.LogError(exception, exception.Message);

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync(
                errorMessage,
                cancellationToken);

            return true;
        }
    }
}