using Microsoft.Extensions.DependencyInjection;

namespace AvalonStalker.Core
{
    public static class DiExtension
    {
        public static IServiceCollection SetupCoreDi(this IServiceCollection services)
        {
            return services;
        }
    }
}