using PersonApp.Core.Entities.Api;

namespace PersonApp.Infrastructure.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Result>> GetPersonsAsync(string url, int limit = 10);

    }
}
