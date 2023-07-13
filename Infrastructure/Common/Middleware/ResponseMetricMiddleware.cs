using System.Diagnostics;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Middleware; 

public class ResponseMetricMiddleware
{
    private readonly RequestDelegate _request;

    public ResponseMetricMiddleware(RequestDelegate request)
    {
        _request = request ?? throw new ArgumentNullException(nameof(request));
    }

    public async Task Invoke(HttpContext httpContext, MetricReporter reporter)
    {
        var path = httpContext.Request.Path.Value;
            if (path == "/api/metrics")
        {
            await _request.Invoke(httpContext);
            return;
        }
        var sw = Stopwatch.StartNew();

        try
        {
            await _request.Invoke(httpContext);
        }
        finally
        {
            sw.Stop();
            reporter.RegisterRequest();
            reporter.RegisterResponseTime(httpContext.Response.StatusCode, httpContext.Request.Method, sw.Elapsed);
        }
    }
}