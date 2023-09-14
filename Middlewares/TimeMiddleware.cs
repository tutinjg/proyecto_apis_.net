using System.Data;
using System.Threading;
using System.Net.Cache;
public class TimeMiddleware
{
    readonly RequestDelegate next;
    // Nos ayuda a invocar el middleware que sigue dentro del ciclo
    public TimeMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }
    
    public async Task Invoke(HttpContext context)
    {   
        if(context.Request.Query.Any(p=> p.Key == "time"))
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            return;
        }

        await next(context);
    }
}
    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }