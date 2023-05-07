using Labb_4_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb_4_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinkController : ControllerBase
    {
        private readonly ILinkRepository _linkRepository;

        public LinkController(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLinks()
        {
            return Ok(await _linkRepository.GetAllLinksAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLink(int id)
        {
            var link = await _linkRepository.GetLinkByIdAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            return Ok(link);
        }

        
       

    }
}
