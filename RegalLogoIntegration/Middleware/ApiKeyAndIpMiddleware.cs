using Microsoft.Extensions.Options;
using System.Net;

public class ApiSecurityOptions
{
    public List<string> ApiKeys { get; set; } = new();
    public List<string> AllowedIPs { get; set; } = new();
}

public class ApiKeyAndIpMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ApiSecurityOptions _options;

    public ApiKeyAndIpMiddleware(RequestDelegate next, IOptions<ApiSecurityOptions> options)
    {
        _next = next;
        _options = options.Value;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        
        if (!context.Request.Headers.TryGetValue("X-API-KEY", out var apiKey) ||
            !_options.ApiKeys.Contains(apiKey))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Yetkisiz: API anahtarı eksik veya geçersiz.");
            return;
        }

        
        var remoteIp = context.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        if (!_options.AllowedIPs.Contains(remoteIp))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync($"Yasaklı: IP {remoteIp} İzinli değil.");
            return;
        }

        await _next(context);
    }
}