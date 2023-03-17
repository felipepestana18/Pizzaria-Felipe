using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pizzaria.PizzaAPI.Data.ValueObjects;
using Pizzaria.PizzaAPI.Model;
using Pizzaria.PizzaAPI.Model.Context;

namespace Pizzaria.PizzaAPI.Repository
{
    public class PizzariaRepository : IPizzaRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;



        public PizzariaRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<IEnumerable<PizzaVO>> FindAll()
        {
            List<Pizza> pizzas = await _context.Pizzas.ToListAsync();
            return _mapper.Map<List<PizzaVO>>(pizzas);
        }

        public async Task<PizzaVO> FindById(int id)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<PizzaVO>(pizza);

        }

        public async Task<PizzaVO> Create(PizzaVO vo)
        {
            Pizza pizza = _mapper.Map<Pizza>(vo);
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return _mapper.Map<PizzaVO>(pizza);
        }

        public async Task<PizzaVO> Update(PizzaVO vo)
        {
            Pizza pizza = _mapper.Map<Pizza>(vo);
            _context.Pizzas.Update(pizza);
            await _context.SaveChangesAsync();
            return _mapper.Map<PizzaVO>(pizza);
        }


        public async Task<bool> Delete(int id)
        {
            var pizza = await _context.Pizzas.FirstOrDefaultAsync(c => c.Id == id);

            if (pizza == null) return false;

            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
