using Labb_4_API.Data;
using Microsoft.EntityFrameworkCore;
using PersonModels;

namespace Labb_4_API.Services
{
    public class HobbyRepository : IHobbyRepository
    {
        private readonly AppDbContext _context;

        public HobbyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hobby>> GetAllHobbiesAsync()
        {
            return await _context.Hobbies.ToListAsync();
        }

        public async Task<Hobby> GetHobbyByIdAsync(int id)
        {
            return await _context.Hobbies.FindAsync(id);
        }

        public async Task<Hobby> AddHobbyAsync(Hobby hobby)
        {
            var entry = await _context.Hobbies.AddAsync(hobby);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task UpdateHobbyAsync(Hobby hobby)
        {
            _context.Entry(hobby).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHobbyAsync(int id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby != null)
            {
                _context.Hobbies.Remove(hobby);
                await _context.SaveChangesAsync();
            }
        }
    }
}
