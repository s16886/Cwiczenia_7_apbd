using Cwiczenia7.Exceptions;
using Cwiczenia7.Models;
using Cwiczenia7.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cwiczenia7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public ClientsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveClientAsync(int id)
        {
            
            try
            {
                await _dbService.RemoveClientAsync(id);
                return Ok("Client succesfully deleted.");
            }
            catch(ClientNotFoundException exc1)
            {
                return BadRequest(exc1.Message);
            }
            catch(TripsAssignedException exc2)
            {
                return BadRequest(exc2.Message);
            }
        }
    }
}
