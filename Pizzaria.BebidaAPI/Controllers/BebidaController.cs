using Microsoft.AspNetCore.Mvc;
using Pizzaria.BebidaAPI.Data.ValueObjects;
using Pizzaria.BebidaAPI.Repository;

namespace Pizzaria.BebidaAPI.Controllers
{
    [ApiController]
    [Route("api/v1/Bebida/")]

    public class BebidaController : Controller
    {
        private readonly IBebidaRepository _BebidasRepository;

        public BebidaController(IBebidaRepository bebidaRepository)
        {
            _BebidasRepository = bebidaRepository ?? throw new
             ArgumentNullException(nameof(bebidaRepository));
        }

        [HttpGet("find-all")]
        public async Task<ActionResult<BebidaVO>> GetAll()
        {
           var bebidas =  await _BebidasRepository.GetAll();
           if (bebidas == null) return NotFound();
           return Ok(bebidas);  
        }

        [HttpGet("find-by-id/{id}")]
        public async Task<ActionResult<BebidaVO>> GetById(int id)
        {
            var bebida = await _BebidasRepository.GetById(id);
            if(bebida == null) return NotFound();
            return Ok(bebida);
        }

        [HttpPost("create")]
        public async Task<ActionResult<BebidaVO>> Create(BebidaVO vo)
        {
           var bebida = await _BebidasRepository.Create(vo);
            if(bebida == null) return NotFound();
            return Ok(bebida);
        }

        [HttpPut("update")]
        public async Task<ActionResult<BebidaVO>> Update(BebidaVO vo)
        {
            var bebida = await _BebidasRepository.Update(vo);
            if (bebida == null) return NotFound();
            return Ok(bebida);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<BebidaVO>> Delete(int id) 
        {
            var status = await _BebidasRepository.Delete(id);
            if (!status) NotFound();

            return Ok();  
        }
       
    }
}
