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

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> GetByCnpj(int clienteId, bool IncludeAvaliacao)
        {
            try
            {
                var myResult = await _repo.GetClientAsynckById(clienteId, IncludeAvaliacao);
                return Ok(myResult);
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("ByCnpj/{cnpj}")]
        public async Task<IActionResult> GetByCnpj(string cnpj)
        {
            try
            {
                var myResult = await _repo.GetClientAsyncByCnpj(cnpj);
                if (myResult == null)
                {
                    return BadRequest("NULL");
                }
                return Ok(myResult);
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("tocliente/{twofields}")]
        public async Task<IActionResult> GetByTwo(bool twofields)
        {
            List<ClienteDTO> clientesRetornoDTO = new List<ClienteDTO>();
            List<ClienteMinDTO> clientesRetornoMinDTO = new List<ClienteMinDTO>();

            try
            {
                var myResult = await _repo.GetAllClientTwoFieldsAsynch(false);

                if (twofields)
                {
                    
                    foreach (var item in myResult)
                    {
                        clientesRetornoDTO.Add(new ClienteDTO { Id = item.Id, RazaoSocial = item.RazaoSocial });
                    }
                }
                else
                {
                    
                    foreach (var item in myResult)
                    {
                        clientesRetornoMinDTO.Add(new ClienteMinDTO { Id = item.Id });
                    }
                }


                if ((clientesRetornoDTO == null) || (clientesRetornoMinDTO == null))
                {
                    return BadRequest("NULL");
                }

                if(twofields){
                    return Ok(clientesRetornoDTO);
                }
                return Ok(clientesRetornoMinDTO);
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

        [HttpPut("{clienteId}")]
        public async Task<IActionResult> Put(int clienteId, Cliente cliente)
        {
            try
            {
                var clienteModel = await _repo.GetClientAsynckById(clienteId, false);
                if (clienteModel == null) return NotFound("Cliente não encontrado !!!");

                _repo.UpdateData(cliente);

                if (await _repo.SaveDataAsynch())
                {
                    return Ok(cliente);
                }
            }
            catch (System.Exception ex)

            {
                return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest("Bad Request Error !!!");
        }

        [HttpDelete("{clienteId}")]
        public async Task<IActionResult> Delete(int clienteId)
        {
            try
            {
                var clienteModel = await _repo.GetClientAsynckById(clienteId, false);
                if (clienteModel == null) return NotFound();

                _repo.DeleteData(clienteModel);

                if (await _repo.SaveDataAsynch())
                {
                    return Ok(new { mensagem = "Deleted with Success !!" });
                }
            }
            catch (System.Exception ex)

            {
                return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest("Bad Request Error !!!");
        }
    }
}