using Microsoft.AspNetCore.Builder;

namespace MoviesApp.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UsePersonalRequestLog(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestMiddlewareLog>();
    }
}