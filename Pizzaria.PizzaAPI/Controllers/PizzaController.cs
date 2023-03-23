using Microsoft.AspNetCore.Mvc;
using Pizzaria.PizzaAPI.Data.ValueObjects;
using Pizzaria.PizzaAPI.Repository;

namespace Pizzaria.PizzaAPI.Controllers
{
    [ApiController]
    [Route("api/v1/Pizza/")]
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _Pizzarepository;

        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _Pizzarepository = pizzaRepository ?? throw new
             ArgumentNullException(nameof(pizzaRepository));


        }
        [HttpGet("find-all")]
        public async Task<ActionResult<PizzaVO>> FindAll()
        {
            var pizza = await _Pizzarepository.FindAll();
            if (pizza == null) return NotFound();
            return Ok(pizza);
        }

        [HttpGet("find-by-id/{id}")]
        public async Task<ActionResult<PizzaVO>> FindAll(int id)
        {
            var pizza = await _Pizzarepository.FindById(id);
            if (pizza == null) return NotFound();
            return Ok(pizza);
        }

        [HttpPost("create")]
        public async Task<ActionResult<PizzaVO>> Create([FromBody] PizzaVO model)
        {

            var pizza = await _Pizzarepository.Create(model);
            if (pizza == null) return BadRequest();
            return Ok(pizza);

        }
        [HttpPut("update-pizza/{id}")]
        public async Task<ActionResult<PizzaVO>> Update([FromBody] PizzaVO model)
        {
            var pizza = await _Pizzarepository.Update(model);
            if (pizza == null) return BadRequest();
            return Ok(pizza);

        }
        [HttpDelete("remove-pizza/{id}")]
        public async Task<ActionResult<PizzaVO>> Delete(int id)
        {
            var status = await _Pizzarepository.Delete(id);
            if (!status) return NotFound();
            return Ok();

        }
    }
}
