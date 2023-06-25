using Microsoft.AspNetCore.Mvc;
using SmartDonnes_Api.Models;

namespace SmartDonnes_Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoController : ControllerBase
    {

        private readonly IRepository _repo;
        public AvaliacaoController(IRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var myResult = await _repo.GetAllAvalAsynch(true);
                return Ok(myResult);
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Avaliacao avaliacao)
        {
            try
            {
                _repo.CreateData(avaliacao);

                if (await _repo.SaveDataAsynch())
                {
                    return Ok(avaliacao);
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