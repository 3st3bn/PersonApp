using PersonApp.Core.Entities.Api;
using PersonApp.Infrastructure.Interfaces;
using PersonApp.Services.Interfaces;

namespace MovieApp.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Result>> GetPersonAsync(string url, int limit = 10)
        {
            return await _personRepository.GetPersonsAsync(url, limit);
        }
    }
}
