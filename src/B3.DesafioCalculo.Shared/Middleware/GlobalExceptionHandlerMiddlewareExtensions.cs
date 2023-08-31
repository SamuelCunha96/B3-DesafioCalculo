using Microsoft.AspNetCore.Builder;

namespace B3.DesafioCalculo.Shared.Middleware
{
    public static class GlobalExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
