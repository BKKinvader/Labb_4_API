using Labb_4_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Labb_4_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HobbyController : ControllerBase
    {
        private readonly IHobbyRepository _hobbyRepository;

        public HobbyController(IHobbyRepository hobbyRepository)
        {
            _hobbyRepository = hobbyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetHobbies()
        {
            return Ok(await _hobbyRepository.GetAllHobbiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHobby(int id)
        {
            var hobby = await _hobbyRepository.GetHobbyByIdAsync(id);
            if (hobby == null)
            {
                return NotFound();
            }
            return Ok(hobby);
        }

        // Other CRUD operations for Hobby
    }
}
