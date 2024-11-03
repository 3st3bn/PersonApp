using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MovieApp.Services.Implementations;
using PersonApp.Infrastructure.Interfaces;
using PersonApp.Infrastructure.Repositories;
using PersonApp.Services.Implementations;
using PersonApp.Services.Interfaces;

namespace PersonApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<IPersonRepository, PersonRepository>();
            builder.Services.AddSingleton<ILoadingService, LoadingService>();
            builder.Services.AddSingleton<IPersonService, PersonService>();
            builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();
            Startup.ServicesProvider = app.Services;
            return app;
        }
    }
}
