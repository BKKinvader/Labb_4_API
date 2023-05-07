using Labb_4_API.Data;
using Labb_4_API.DTO;
using Microsoft.EntityFrameworkCore;
using PersonModels;

namespace Labb_4_API.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            return await _context.Persons.ToListAsync();
        }
        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }
        public async Task<IEnumerable<Hobby>> GetPersonHobbiesAsync(int personId)
        {
            return await _context.PersonHobbies
                        .Where(ph => ph.PersonId == personId)
                        .Select(ph => ph.Hobby)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Link>> GetPersonLinksAsync(int personId)
        {
            var links = await _context.PersonHobbies
                .Include(ph => ph.Links)
                .Where(ph => ph.PersonId == personId)
                .SelectMany(ph => ph.Links)
                .ToListAsync();
            return links;
        }

        //Kontrollerar om Person och Hobby exist
        public async Task<bool> PersonExistsAsync(int personId)
        {
            return await _context.Persons.AnyAsync(p => p.Id == personId);
        }
        public async Task<bool> HobbyExistsAsync(int hobbyId)
        {
            return await _context.Hobbies.AnyAsync(h => h.Id == hobbyId);
        }


        public async Task AddPersonHobbyAsync(int personId, HobbyCreateDto hobbyCreateDto)
        {
            // Skapa en ny Hobby
            var newHobby = new Hobby
            {
                Title = hobbyCreateDto.Title,
                Description = hobbyCreateDto.Description
            };

            // Lägg till den nya hobbyn i databasen
            await _context.Hobbies.AddAsync(newHobby);
            await _context.SaveChangesAsync();

            // Skapa en ny PersonHobby och koppla den till den nya hobbyn och personen
            var newPersonHobby = new PersonHobby
            {
                PersonId = personId,
                HobbyId = newHobby.Id
            };

            // Lägg till den nya PersonHobby i databasen
            await _context.PersonHobbies.AddAsync(newPersonHobby);
            await _context.SaveChangesAsync();
        }



        public async Task<Link> AddPersonHobbyLinkAsync(int personId, int hobbyId, Link link)
        {
            try
            {
                var personHobby = await _context.PersonHobbies
                    .Include(ph => ph.Links)
                    .FirstOrDefaultAsync(ph => ph.PersonId == personId && ph.HobbyId == hobbyId);

                if (personHobby == null)
                {
                    return null;
                }

                personHobby.Links.Add(link);
                await _context.SaveChangesAsync();

                return link;
            }
            catch (Exception ex)
            {
                // Logga felet här, till exempel:
                Console.WriteLine($"Error in AddPersonHobbyLinkAsync: {ex.Message}");
                throw;
            }
        }

    }
}
