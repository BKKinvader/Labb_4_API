using Labb_4_API.Data;
using Microsoft.EntityFrameworkCore;
using PersonModels;

namespace Labb_4_API.Services
{
    public class LinkRepository : ILinkRepository
    {

        private readonly AppDbContext _context;

        public LinkRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<Link> Links => _context.Links;

        public async Task<IEnumerable<Link>> GetAllLinksAsync()
        {
            return await _context.Links.ToListAsync();
        }

        public async Task<IEnumerable<Link>> GetLinksByPersonHobbyIdAsync(int personHobbyId)
        {
            return await _context.Links
                .Where(link => link.PersonHobbyId == personHobbyId)
                .ToListAsync();
        }

        public async Task<Link> GetLinkByIdAsync(int id)
        {
            return await _context.Links.FindAsync(id);
        }

        public async Task<Link> AddLinkAsync(Link link)
        {
            var entry = await _context.Links.AddAsync(link);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task UpdateLinkAsync(Link link)
        {
            _context.Entry(link).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

       
    }
}
