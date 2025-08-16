
using Domain.Exceptions;
using System.Net;

namespace Restaurant.Api.Middlewares;

public class GlobalErrorHandlingMiddleware(
    RequestDelegate next,
    ILogger<GlobalErrorHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);

            if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                await HandleNotFoundEndpointAsync(context);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Oops, bad things happen all time");

            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleNotFoundEndpointAsync(HttpContext httpContext)
    {
        var response = new
        {
            ErrorMessage = $"Endpoint: '{httpContext.Request.Path}', Not Found!",
            StatusCode = (int)HttpStatusCode.NotFound
        };

        await httpContext.Response.WriteAsJsonAsync($"{response}");
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.StatusCode = ex switch
        {
            NotFoundException => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var response = new
        {
            ErrorMessage = ex.Message,
            httpContext.Response.StatusCode
        };

        await httpContext.Response.WriteAsJsonAsync($"{response}");
    }
}
