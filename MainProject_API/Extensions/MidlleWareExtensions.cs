using MainProject_API.Middlewares;

namespace MainProject_API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UseGlobalExceptionHandler(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}