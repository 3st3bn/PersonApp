using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieApp.Services.Implementations;
using PersonApp.Services.Interfaces;

namespace PersonApp.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthenticationService _authService;
        private readonly INavigationService _navigationService;
        private  ILoadingService    _loadingService;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        public LoginViewModel()
        {
            _authService = Startup.GetService<IAuthenticationService>();
            _navigationService = Startup.GetService<INavigationService>();
            _loadingService = Startup.GetService<ILoadingService>();
        }


        [RelayCommand]
        private async Task LoginAsync(string message = "")
        {
            if(Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                await _loadingService.Show();
                if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                {
                    await Toast.Make("Por favor ingrese las credenciales", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();

                    return;
                }
                try
                {
                    var isAuthenticated = await _authService.AuthenticateAsync(Username, Password);
                    if (isAuthenticated)
                    {
                        await _navigationService.NavigateToAsync("PersonPage");
                    }
                    else
                    {
                        await Toast.Make("Credenciales incorrectas", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                    }
                }
                catch (Exception ex)
                {
                    await Toast.Make("Error en el servidor: " + ex.Message, CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }
                finally
                {
                    await _loadingService.Hide();
                }
            }
        }
    }
}
