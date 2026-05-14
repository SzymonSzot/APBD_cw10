using APBD10.DTOs;
using APBD10.Entities;
using APBD10.Exceptions;
using APBD10.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD10.Controllers
{
    [Route("api/[controller]")]
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
    }
}
