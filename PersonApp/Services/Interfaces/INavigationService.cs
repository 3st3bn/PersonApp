namespace PersonApp.Services.Interfaces
{
    public interface INavigationService
    {
        Task NavigateToAsync(string pageKey);
    }
}
