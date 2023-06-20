using Microsoft.AspNetCore.Mvc;
using SmartDonnes_Api.Models;

namespace SmartDonnes_Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository _repo;
        public ClienteController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var myResult = await _repo.GetAllClientAsynch(false);
                return Ok(myResult);
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            try
            {
                _repo.CreateData(cliente);

                if (await _repo.SaveDataAsynch())
                {
                    return Ok(cliente);
                }
                return BadRequest("Dont expectative errors...!");
            }
            catch (System.Exception ex)
            {
                return BadRequest("Found errors => " + ex.Message);
            }
        }
    }
}