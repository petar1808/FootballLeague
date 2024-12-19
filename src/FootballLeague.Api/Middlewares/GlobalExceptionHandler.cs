using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.Api.Middlewares
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = CreateProblemDetails(httpContext, exception);
            httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";

            logger.LogError(exception, "An error occurred: {ProblemDetailsTitle}", problemDetails.Title);

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);
            return true;
        }

        private ProblemDetails CreateProblemDetails(HttpContext httpContext, Exception exception)
        {
            var problemDetails = new ProblemDetails
            {
                Instance = httpContext.Request.Path,
                Status = GetStatusCodeForException(exception),
                Title = GetTitleForException(exception)
            };

            if (exception is ValidationException fluentException)
            {
                problemDetails.Extensions.Add("ValidationErrors", fluentException.Errors
                    .Select(error => new { error.PropertyName, error.ErrorMessage })
                    .ToList());
            }

            return problemDetails;
        }

        private int GetStatusCodeForException(Exception exception)
        {
            return exception switch
            {
                ValidationException => StatusCodes.Status400BadRequest,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
        }

        private string GetTitleForException(Exception exception)
        {
            return exception switch
            {
                ValidationException => "Validation Error",
                KeyNotFoundException => "Resource Not Found",
                _ => "An unexpected error occurred"
            };
        }
    }
}
