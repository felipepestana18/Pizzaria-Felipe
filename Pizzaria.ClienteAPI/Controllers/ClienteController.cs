using Microsoft.AspNetCore.Mvc;
using Pizzaria.ClienteAPI.Data.ValueObject;
using Pizzaria.ClienteAPI.Repository;

namespace Pizzaria.ClienteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("find-all")]
        public async Task<ActionResult<ClienteVO>> GetAll()
        {
            var clientes = await _clienteRepository.GetAll();
            if (clientes == null) return NotFound();
            return Ok(clientes);
        }

        [HttpGet("find-by-id/{id}")]
        public async Task<ActionResult<ClienteVO>> GetById (int id) {
            var cliente = await _clienteRepository.GetById(id);
            if(cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost("create")]
        public async Task<ActionResult<ClienteVO>> Create(ClienteVO vo)
        {
            var cliente = await _clienteRepository.Create(vo);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ClienteVO>> Update(ClienteVO vo)
        {
            var cliente = await _clienteRepository.Update(vo);
            if (cliente == null) return NotFound();
            return Ok(cliente); 
        }
        [HttpDelete("delete{id}")]
        public async Task<ActionResult<bool>> Delete (int id)
        {
            var status = await _clienteRepository.Delete(id);
            if (!status) BadRequest();
            return Ok(status);
        }

    }
}
