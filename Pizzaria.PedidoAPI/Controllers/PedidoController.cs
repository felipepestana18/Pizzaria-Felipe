using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Pizzaria.PedidoAPI.Model;
using Pizzaria.PedidoAPI.Repository;
using Pizzaria.PedidoAPI.Services.IServices;

namespace Pizzaria.PedidoAPI.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet("find-all")]
        public async Task<ActionResult<PedidoVO>> GetAll()
        {
            var pedidos = await _pedidoRepository.GetAll();
            if (pedidos == null) return NotFound();
            return Ok(pedidos);
        }

        [HttpGet("find-by-id")]
        public async Task<ActionResult<PedidoVO>> GetById(int id)
        {
            var pedido = await _pedidoRepository.GetById(id);
            if (pedido == null) return NotFound();
            return Ok(pedido);
        }

        [HttpPost("create")]
        public async Task<ActionResult<PedidoVO>> Create(PedidoVO vo)
        {
            var pedido = await _pedidoRepository.Create(vo);
            if (pedido == null) return BadRequest();
            return Ok(pedido);
        }

        [HttpPut("update")]
        public async Task<ActionResult<PedidoVO>> Update(PedidoVO vo)
        {
            var pedido = await _pedidoRepository.Update(vo);
            if (pedido == null) return BadRequest();
            return Ok(pedido);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<bool>> Delete(int id)
        {

            bool status = await _pedidoRepository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);  
        }

    }
}
