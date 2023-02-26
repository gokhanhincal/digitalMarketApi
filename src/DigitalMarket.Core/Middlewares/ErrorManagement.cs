using Microsoft.AspNetCore.Builder;

namespace DigitalMarket.Core.Middlewares;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseMiddleware<GlobalErrorHandlingMiddleware>();
}