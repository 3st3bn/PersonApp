using PersonApp.Core.Entities.Api;

namespace PersonApp.Services.Interfaces
{
    public interface IPersonService
    {
        Task<List<Result>> GetPersonAsync(string url, int limit = 10);
    }
}
