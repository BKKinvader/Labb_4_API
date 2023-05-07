using Labb_4_API.DTO;
using Labb_4_API.Services;
using Microsoft.AspNetCore.Mvc;
using PersonModels;

namespace Labb_4_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            return Ok(await _personRepository.GetAllPersonsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var person = await _personRepository.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpGet("{id}/hobbies")]
        public async Task<IActionResult> GetPersonHobbies(int id)
        {
            var hobbies = await _personRepository.GetPersonHobbiesAsync(id);
            if (hobbies == null)
            {
                return NotFound();
            }
            return Ok(hobbies);
        }


        [HttpGet("{id}/links")]
        public async Task<IActionResult> GetPersonLinks(int id)
        {
            var links = await _personRepository.GetPersonLinksAsync(id);
            if (links == null)
            {
                return NotFound();
            }
            return Ok(links);
        }


        [HttpPost("{personId}/hobbies")]
        public async Task<ActionResult> AddPersonHobby(int personId, HobbyCreateDto hobbyCreateDto)
        {
            // Kontrollera att personen finns
            var personExists = await _personRepository.PersonExistsAsync(personId);
            if (!personExists)
            {
                return NotFound("Person not found");
            }

            // Anropa AddPersonHobbyAsync för att lägga till hobbyn och koppla den till personen
            await _personRepository.AddPersonHobbyAsync(personId, hobbyCreateDto);

            return Ok();
        }



        //[HttpPost("{personId}/hobbies/{hobbyId}/links")]
        //public async Task<ActionResult<Link>> AddLink(int personId, int hobbyId, [FromBody] Link link)
        //{
        //    // Kontrollera att personen och hobbyn finns
        //    if (!await _personRepository.PersonExistsAsync(personId) || !await _personRepository.HobbyExistsAsync(hobbyId))
        //    {
        //        return NotFound("Person or hobby not found");
        //    }

        //    var addedLink = await _personRepository.AddPersonHobbyLinkAsync(personId, hobbyId, link);

        //    if (addedLink == null)
        //    {
        //        return BadRequest("Failed to add link to hobby");
        //    }

        //    return CreatedAtAction(nameof(AddLink), new { id = addedLink.Id }, addedLink);
        //}

        [HttpPost("{personId}/hobbies/{hobbyId}/links")]
        public async Task<ActionResult<Link>> AddPersonHobbyLinkAsync(int personId, int hobbyId, [FromBody] AddLinkDto addLinkDto)
        {
            // Kontrollera att personen och hobbyn finns
            if (!await _personRepository.PersonExistsAsync(personId) || !await _personRepository.HobbyExistsAsync(hobbyId))
            {
                return NotFound("Person or hobby not found");
            }

            var link = new Link { Url = addLinkDto.Url };
            var addedLink = await _personRepository.AddPersonHobbyLinkAsync(personId, hobbyId, link);

            if (addedLink == null)
            {
                return BadRequest("Failed to add link to hobby");
            }

            return CreatedAtAction(nameof(AddPersonHobbyLinkAsync), new { id = addedLink.Id }, addedLink);
        }






    }
}
