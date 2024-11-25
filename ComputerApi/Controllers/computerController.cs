using ComputerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerApi.Controllers
{
    [Route("comp")]
    [ApiController]
    public class computerController : ControllerBase
    {
        private readonly ComputerContext computerContext;

        public computerController(ComputerContext computerContext)
        {
            this.computerContext = computerContext;
        }
        [HttpPost]
        public async Task<ActionResult<Comp>> Post(CreateComputerDto createComputerDto)
        {
            var cmp = new Comp
            {
                Id = Guid.NewGuid(),
                Brand = createComputerDto.brand,
                Type = createComputerDto.type,
                Display = createComputerDto.display,
                Memory = createComputerDto.memory,
                CreatedTime = DateTime.Now,
                Osld = createComputerDto.Osld
            };

            if (cmp != null)
            {
                await computerContext.Comps.AddAsync(cmp);
                await computerContext.SaveChangesAsync();
                return StatusCode(201, cmp);
            }
            return BadRequest();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAllCompByID(Guid id)
        {
            var os = computerContext.Osystems.Include(os => os.Comps).Where(c => c.Id == id);

            if (os != null)
            {
                return Ok(os);
            }
            return BadRequest();
        }

        
    }

}
