using System.Diagnostics;

namespace Million.Api.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var endpoint = context.Request.Path;
        _logger.LogDebug("➡️ Init request in endpoint: {Endpoint}", endpoint);

        var stopwatch = Stopwatch.StartNew();

        await _next(context); // sigue con la cadena de middlewares

        stopwatch.Stop();
        _logger.LogDebug("✅ End request in endpoint: {Endpoint} in {ElapsedMilliseconds} ms",
            endpoint, stopwatch.ElapsedMilliseconds);
    }
}
