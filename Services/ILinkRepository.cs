using PersonModels;

namespace Labb_4_API.Services
{
    public interface ILinkRepository
    {
        Task<IEnumerable<Link>> GetAllLinksAsync();
        Task<IEnumerable<Link>> GetLinksByPersonHobbyIdAsync(int personHobbyId);
        Task<Link> GetLinkByIdAsync(int id);
        Task<Link> AddLinkAsync(Link link);
        Task UpdateLinkAsync(Link link);
        
    }
}
