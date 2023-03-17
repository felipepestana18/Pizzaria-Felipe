using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Pizzaria.ClienteAPI.Data.ValueObject;
using Pizzaria.ClienteAPI.Model;
using Pizzaria.ClienteAPI.Model.Context;

namespace Pizzaria.ClienteAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly MySQLContext _context;
        private IMapper _mapper;

        public ClienteRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteVO>> GetAll()
        {
            List<Cliente> clientes = await _context.Clientes.ToListAsync();
            return _mapper.Map<List<ClienteVO>>(clientes); 
        }

        public async Task<ClienteVO> GetById(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<ClienteVO>(cliente);
        }

        public async Task<ClienteVO> Create(ClienteVO vo)
        {
            Cliente cliente = _mapper.Map<Cliente>(vo);
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();  
            return _mapper.Map<ClienteVO>(cliente);
        }

        public async Task<ClienteVO> Update(ClienteVO vo)
        {
            Cliente cliente = _mapper.Map<Cliente>(vo);
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClienteVO>(cliente);

        }
        public async Task<bool> Delete(int id)
        {
            Cliente cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null) return false;
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;    
        }

 
    }
}
