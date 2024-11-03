using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PersonApp;
using PersonApp.Core.Entities.Api;
using PersonApp.Services.Interfaces;
using System.Collections.ObjectModel;

namespace PersonApp.ViewModels
{
    public partial class PersonViewModel : ObservableObject
    {
        private readonly IPersonService _personService;
        private ILoadingService _loadingService;


        [ObservableProperty]
        private ObservableCollection<Result> results;

        public PersonViewModel()
        {
            _personService = Startup.GetService<IPersonService>();
            _loadingService = Startup.GetService<ILoadingService>();
            Results = new ObservableCollection<Result>();
            OnAppearing();
        }

        [RelayCommand]
        private async Task OnAppearing(string message = "")
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                await _loadingService.Show(string.IsNullOrWhiteSpace(message) ? "Cargando..." : message);

                try
                {
                    string apiUrl = "https://localhost:44355/api/Person/persons";
                    var personList = await _personService.GetPersonAsync(apiUrl);

                    Results.Clear(); // Limpia la colección antes de añadir nuevos resultados
                    foreach (var person in personList)
                    {
                        Results.Add(person);
                    }
                }
                catch (Exception ex)
                {
                    MessagingCenter.Send(this, "Error", ex.Message);
                }
                finally
                {
                    await _loadingService.Hide(); // Asegúrate de ocultar el popup al final
                }
            }
            else
            {
                await Toast.Make("No Internet Connection", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }

        }
    }
}
