using CTeleport.DistanceCalculator.Api.Common.Extensions;
using CTeleport.DistanceCalculator.Core.Common.Exceptions;
using Order.Application.Common.Exceptions;
using System.Net;

namespace Order.API.Configs.Middleware;

/// <summary>
/// middleware handles every exceptions
/// </summary>
public class ExceptionHandleMiddleware
{
    private readonly ILogger<ExceptionHandleMiddleware> _logger;
    private readonly RequestDelegate _next;

    /// <summary>
    /// create <see cref="ExceptionHandleMiddleware"/> instance
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public ExceptionHandleMiddleware(RequestDelegate next, ILogger<ExceptionHandleMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// use middleware
    /// </summary>
    /// <param name="context"></param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DomainException ex)
        {
            _logger.LogError(ex,
                "Global exception handle. Catched exception occured while execute domain operations");

            var problemDetails = ex.GenerateProblemDetails(context,
                code: HttpStatusCode.InternalServerError,
                message: "Error occured while execute some domain operations");

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (InfrastructureException ex)
        {
            _logger.LogError(ex, "Global exception handle. Catched exception occured while execute infrastructure operations");

            var problemDetails = ex.GenerateProblemDetails(context,
                code: HttpStatusCode.InternalServerError,
                message: "Error occured while execute some infrastructure operations");

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Global exception handle. Catched exception occured while execute operations");

            var problemDetails = ex.GenerateProblemDetails(context,
                code: HttpStatusCode.InternalServerError,
                message: "Error occured while execute some operations");

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}