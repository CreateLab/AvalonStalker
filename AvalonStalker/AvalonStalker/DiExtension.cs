using AvalonStalker.ViewModels.Abstract;
using AvalonStalker.ViewModels.Concrete;
using AvalonStalker.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AvalonStalker
{
    public static class DiExtension
    {
        public static IServiceCollection SetupGuiDi(this IServiceCollection services)
        {
            services.AddScoped<MainWindowViewModel, MainWindowViewModel>();
            services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
            services.AddSingleton<RequestViewModel, RequestViewModel>();
            return services;
        }
    }
}