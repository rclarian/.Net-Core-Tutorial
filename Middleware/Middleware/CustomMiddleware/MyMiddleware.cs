
namespace Middleware.CustomMiddleware
{
    public class MyMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //Before logic
            await context.Response.WriteAsync("Custom Middle started\n\n");
            await next(context);

            //After logic
            await context.Response.WriteAsync("Custom Middle finished");
        }
    }
}
