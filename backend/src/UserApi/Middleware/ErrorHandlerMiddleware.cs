using System.Net;
using System.Text.Json;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, _logger);
             
            var response = context.Response;
            response.ContentType = "application/json";

             switch(ex)
            {
                case DuplicateEmailException e:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
            }

            var result = JsonSerializer.Serialize(new { message = ex?.Message });
            await response.WriteAsync(result);

        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<ErrorHandlerMiddleware> logger)
    {
        logger.LogError(exception, "An unhandled exception has occurred");

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = JsonSerializer.Serialize(new { error = "An unexpected error has occurred" });
        return context.Response.WriteAsync(result);
    }
}
