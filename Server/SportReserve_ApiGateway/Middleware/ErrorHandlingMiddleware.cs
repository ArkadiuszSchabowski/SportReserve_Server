using SportReserve_ApiGateway.Exceptions;

namespace SportReserve_ApiGateway.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (HttpResponseNullException e)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(e.Message);
            }

            catch (Exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Server error!");
            }
        }
    }
}
