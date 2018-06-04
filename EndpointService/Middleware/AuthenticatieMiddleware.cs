using System.Threading.Tasks;
using AuthenticatieService.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace EndpointService.Middleware
{
    public class AuthenticatieMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthenticatieService _service;

        public AuthenticatieMiddleware(RequestDelegate next, IAuthenticatieService service)
        {
            _next = next;
            _service = service;
        }

        public Task InvokeAsync(HttpContext context)
        {
            var authenticationHeader = context.Request.Headers["Authorization"].ToString();

            if (_service.IsTokenValid(authenticationHeader).Result)
                return _next(context);

            context.Response.StatusCode = 401;
            return context.Response.WriteAsync("Invalid Token");
        }
    }

    #region ExtensionMethod
    public static class AuthenticatieMiddlewareExtension
    {
        public static IApplicationBuilder EnableAuthenticatieMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<AuthenticatieMiddleware>();
            return app;
        }
    }
    #endregion
}
