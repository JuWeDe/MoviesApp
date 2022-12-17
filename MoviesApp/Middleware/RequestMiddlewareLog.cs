using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MoviesApp.Middleware;

public class RequestMiddlewareLog
{
    private readonly RequestDelegate nextData;

    public RequestMiddlewareLog(RequestDelegate next)
    {
        nextData = next;
    }

    public async Task Invoke(HttpContext httpContext, ILogger<RequestMiddlewareLog> logger)
    {
        if (httpContext.Request.Path.StartsWithSegments("/Actors"))
        {
            logger.LogTrace("Request: {RequestPath}  Method: {RequestMethod}", httpContext.Request.Path, httpContext.Request.Method);
            if (httpContext.Request.Method == HttpMethod.Post.Method)
            {
                foreach (var item in httpContext.Request.Form)
                {
                    logger.LogTrace("Key: {ItemKey}  Value: {ItemValue}", item.Key, item.Value);
                }
            }
        }
        await nextData(httpContext);
    }
}