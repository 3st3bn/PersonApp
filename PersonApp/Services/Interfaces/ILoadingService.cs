namespace PersonApp.Services.Interfaces
{
    public interface ILoadingService
    {
        Task Show(string message = "Loading...");
        Task Hide();
    }
}
