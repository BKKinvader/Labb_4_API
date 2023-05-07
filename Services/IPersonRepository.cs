using Labb_4_API.DTO;
using PersonModels;

namespace Labb_4_API.Services
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonsAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task<IEnumerable<Hobby>> GetPersonHobbiesAsync(int personId);
        Task<IEnumerable<Link>> GetPersonLinksAsync(int personId);
        //Task AddPersonHobbyAsync(int personId, string hobbyTitle, string hobbyDescription);
        Task AddPersonHobbyAsync(int personId, HobbyCreateDto hobbyCreateDto);
        Task<Link> AddPersonHobbyLinkAsync(int personId, int hobbyId, Link link);
        Task<bool> PersonExistsAsync(int personId);
        Task<bool> HobbyExistsAsync(int hobbyId);

    }

}
