using APBD10.DTOs;
using APBD10.Entities;
using APBD10.Exceptions;
using APBD10.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD10.Controllers
{
    [Route("api/pcs")]
    [ApiController]
    public class PcComponentController(IDbService dbService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await dbService.GetAllPcsAsync();
                return Ok(res);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpGet("{id:int}/components")]
        public async Task<IActionResult> GetPcComponents(int id)
        {
            try
            {
                var res = await dbService.GetPcByIdAsync(id);
                return Ok(res);
            }
            
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            };
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostPcDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var res = await dbService.PostPc(dto);
            
            return Ok(res);
        }
    }
}
