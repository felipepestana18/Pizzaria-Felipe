using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Pizzaria.PedidoAPI.Model;
using Pizzaria.PizzaAPI.Model;
using Pizzaria.PizzaAPI.Model.Context;

namespace Pizzaria.PedidoAPI.Repository
{
    public class PedidoRepository : IPedidoRepository
    {

        private readonly MySQLContext _context;
        private IMapper _mapper;



        public PedidoRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<IEnumerable<PedidoVO>> GetAll()
        {
            var pedidoFeito = new Pedido(); 
            List<Pedido> pedidos = new List<Pedido>();
            var buscarPedidos = _context.Pedidos.Find();

            pedidos.Add(buscarPedidos);

            foreach (var pedido in pedidos)
            {

                if (pedido != null)
                {
                    var IdPizzas = await _context.PedidoPizzas.Where(c => c.IdPedido == pedido.Id).ToListAsync();
                    var IdBebidas = await _context.PedidoPizzas.Where(c => c.IdPedido == pedido.Id).ToListAsync();

                    if (IdPizzas.Count > 0)
                    {
                        List<Pizza> pizzas = new List<Pizza>();
                        List<Bebida> bebidas = new List<Bebida>();
                        decimal totalPedidoPizza = 0;

                        foreach (var Idpizza in IdPizzas)
                        {
                            pizzas = await _context.Pizzas.Where(c => c.Id == Convert.ToInt32(Idpizza)).ToListAsync();
                        }

                        foreach (var IdBebida in IdBebidas)
                        {
                            bebidas = await _context.Bebidas.Where(c => c.Id == Convert.ToInt32(IdBebida)).ToListAsync();

                        }

                        pedidoFeito.Pizzas = pizzas;
                        pedidoFeito.Bebidas = bebidas;

                        foreach (var bebida in pedido.Bebidas)
                        {
                            totalPedidoPizza += bebida.Preco;
                            pedido.QtdBebidas++;

                        }
                        foreach (var pizza in pedido.Pizzas)
                        {
                            totalPedidoPizza += pizza.Preco;
                            pedido.QtdPizza++;
                        }

                    }
                }

            }

            return _mapper.Map<List<PedidoVO>>(pedidoFeito);

        }

        public Task<PedidoVO> GetById(int id)
        {
            throw new NotImplementedException();
        }


        public Task<PedidoVO> Create(PedidoVO vo)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoVO> Update(PedidoVO vo)
        {
            throw new NotImplementedException();
        }


        public Task<PedidoVO> Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
