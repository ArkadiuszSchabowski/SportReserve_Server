using Microsoft.AspNetCore.Http;
using SportReserve_ApiGateway.Exceptions;
using SportReserve_Shared.Exceptions;

namespace SportReserve_Shared.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestException e)
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

            catch (NotFoundException e)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }
            catch (ConflictException e)
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Błąd serwera!");
            }
        }
    }
}
