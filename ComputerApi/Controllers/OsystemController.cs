using ComputerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ComputerApi.Controllers
{
    [Route("osystem")]
    [ApiController]
    public class OsystemController : ControllerBase
    {
        private readonly ComputerContext computerContext;

        public OsystemController(ComputerContext computerContext)
        {
            this.computerContext = computerContext;
        }

        [HttpPost]
        public async Task<ActionResult<Osystem>> Post(CreatedOsDto createdOsDto)
        {
            var os = new Osystem
            {
                Id = Guid.NewGuid(),
                Name = createdOsDto.Name
            };

            if (os == null) 
            { 
              await computerContext.Osystems.AddAsync(os);
               await computerContext.SaveChangesAsync();
                return StatusCode(201,os);

            }
            return BadRequest();

            
        }
        [HttpGet]
        public async Task<ActionResult<Osystem>> Get()
        {
            return Ok(await computerContext.Osystems.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Osystem>> GetById(Guid id)
        {
            var os = computerContext.Osystems.FirstOrDefaultAsync(x => x.Id == id);
            if (os != null)
            {
                return Ok(os);
            }

            return NotFound(new { Message = "Nincs ilyen találat"});
        }
    }
}
