using PersonApp.Services.Interfaces;

namespace MovieApp.Services.Implementations
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToAsync(string pageKey)
        {
            if (pageKey == "PersonPage")
            {
                await Shell.Current.GoToAsync("//PersonPage");
            }
        }
    }
}
