using BusinessApi.Middlware;

namespace BusinessApi.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder AddGlobalErrorHandling(this IApplicationBuilder app) 
        => app.UseMiddleware<GlobalExceptionHandlerMiddlware>();
}