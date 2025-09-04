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

            catch (UnauthorizedException)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Please log in to access this resource.");
            }

            catch (ForbiddenException)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("You don't have permission to perform this action.");
            }

            catch (Exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Server error!");
            }
        }
    }
}
