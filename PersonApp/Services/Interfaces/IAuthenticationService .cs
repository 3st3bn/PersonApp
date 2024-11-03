namespace PersonApp.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string username, string password);
    }
}
