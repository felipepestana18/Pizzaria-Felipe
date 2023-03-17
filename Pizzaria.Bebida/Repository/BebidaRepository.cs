using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Pizzaria.BebidaAPI.Data.ValueObjects;
using Pizzaria.BebidaAPI.Model;
using Pizzaria.BebidaAPI.Model.Context;

namespace Pizzaria.BebidaAPI.Repository
{
    public class BebidaRepository : IBebidaRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;



        public BebidaRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<BebidaVO> GetById(int id)
        {
            var bebida = await _context.Bebidas.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<BebidaVO>(bebida);
        }

        public async Task<IEnumerable<BebidaVO>> GetAll()
        {
            List<Bebida> bebidas = await _context.Bebidas.ToListAsync();
            return _mapper.Map<List<BebidaVO>>(bebidas);
        }

        public async Task<BebidaVO> Create(BebidaVO vo)
        {
            Bebida bebida = _mapper.Map<Bebida>(vo);
            _context.Bebidas.Add(bebida);
            await _context.SaveChangesAsync();
            return _mapper.Map<BebidaVO>(bebida);
        }
        
        public async Task<bool> Delete(int id)
        {
            var bebida = _context.Bebidas.FirstOrDefaultAsync(c => c.Id == id);
            if (bebida == null) return false;
            _context.Remove(bebida);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<BebidaVO> Update(BebidaVO vo)
        {
            var bebida = _mapper.Map<BebidaVO>(vo);
             _context.Update(bebida);
            await _context.SaveChangesAsync();
            return _mapper.Map<BebidaVO>(bebida);
        }
    }
}
