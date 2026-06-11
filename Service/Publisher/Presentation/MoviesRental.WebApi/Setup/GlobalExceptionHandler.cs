using Amazon.Runtime;
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

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            (int statusCode, string errorMessage) = exception switch
            {
                ArgumentNullException argumentException => (500, argumentException.Message),
                DomainException domainException => (500, domainException.Message),
                SqlException sqlException => (500, sqlException.Message),
                ValidationException validationException => (500, validationException.Message),
                _ => (500, "Something went wrong")
            };

            logger.LogError(exception, exception.Message);
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(errorMessage, cancellationToken);
            return true;
        }

        bool IExceptionHandler.Handle(IExecutionContext executionContext, Exception exception)
        {
            throw new NotImplementedException();
        }

        Task<bool> IExceptionHandler.HandleAsync(IExecutionContext executionContext, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
