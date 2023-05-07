using PersonModels;

namespace Labb_4_API.Services
{
    public interface IHobbyRepository
    {
        Task<IEnumerable<Hobby>> GetAllHobbiesAsync();
        Task<Hobby> GetHobbyByIdAsync(int id);
        Task<Hobby> AddHobbyAsync(Hobby hobby);
        Task UpdateHobbyAsync(Hobby hobby);
        Task DeleteHobbyAsync(int id);
    }
}
