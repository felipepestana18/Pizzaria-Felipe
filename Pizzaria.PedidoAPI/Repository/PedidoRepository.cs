using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Pizzaria.ClienteAPI.Model;
using Pizzaria.PedidoAPI.Model;
using Pizzaria.PedidoAPI.Services.IServices;
using Pizzaria.PizzaAPI.Model;
using Pizzaria.PizzaAPI.Model.Context;
using System.Collections.Immutable;

namespace Pizzaria.PedidoAPI.Repository
{
    public class PedidoRepository : IPedidoRepository
    {

        private readonly MySQLContext _context;
        private IMapper _mapper;


        private readonly IBebidaService _bebidaService;
        private readonly IPizzaService _pizzaService;
        private readonly IClienteService _clienteService;

        public PedidoRepository(MySQLContext context, IMapper mapper, IBebidaService bebidaService, IPizzaService pizzaService, IClienteService clienteService)
        {
            _context = context;
            _mapper = mapper;
            _bebidaService = bebidaService;
            _pizzaService = pizzaService;
            _clienteService = clienteService; ;

        }

        public async Task<IEnumerable<PedidoVO>> GetAll()
        {
            var pedidoFeito = new Pedido();
            List<Pedido> pedidos = new List<Pedido>();
            List<Pedido> pedidosRetorno = new List<Pedido>();

            var buscarPedidos = await _context.Pedidos.ToListAsync();
            if (buscarPedidos != null)
            {
                pedidos = buscarPedidos;
                
                foreach (var pedido in pedidos)
                {

                    pedido.Cliente = await _clienteService.GetClienteById(pedido.IdCliente);

                    if (pedido != null)
                    {

                        var IdPizzas = await _context.PedidoPizzas.AsNoTracking().Where(c => c.IdPedido == pedido.Id).ToListAsync();
                        var IdBebidas = await _context.PedidoBebidas.AsNoTracking().Where(c => c.IdPedido == pedido.Id).ToListAsync();

                        if (IdPizzas.Count > 0)
                        {
                            List<Pizza> pizzas = new List<Pizza>();
                            List<Bebida> bebidas = new List<Bebida>();

                            foreach (var id in IdPizzas)
                            {
                                var pizza = await _pizzaService.GetPizzaById(Convert.ToInt32(id.IdPizza));
                                pizzas.Add(pizza);
                            }

                            foreach (var id in IdBebidas)
                            {
                                var bebida = await _bebidaService.GetBebidaById(Convert.ToInt32(id.IdBebida));
                                bebidas.Add(bebida);

                            }


                            pedido.Pizzas = pizzas;
                            pedido.Bebidas = bebidas;

                        }
                        pedidosRetorno.Add(pedido);
                    }
                }
            }

            
            return _mapper.Map<List<PedidoVO>>(pedidosRetorno);

        }

        public async Task<PedidoVO> GetById(int id)
        {
            var pedido = new Pedido();
            pedido = _context.Pedidos.AsNoTracking().FirstOrDefault(c => c.Id == id);

            if (pedido != null)
            {
                var IdPizzas = await _context.PedidoPizzas.AsNoTracking().Where(c => c.IdPedido == pedido.Id).ToListAsync();
                var IdBebidas = await _context.PedidoBebidas.AsNoTracking().Where(c => c.IdPedido == pedido.Id).ToListAsync();

                List<Pizza> pizzas = new List<Pizza>();
                List<Bebida> bebidas = new List<Bebida>();

                foreach (var IdBebida in IdBebidas)
                {
                    Bebida bebida = await _bebidaService.GetBebidaById(Convert.ToInt32(IdBebida));
                    bebidas.Add(bebida);
                }


                foreach (var IdPizza in IdPizzas)
                {
                    Pizza pizza = await _pizzaService.GetPizzaById(Convert.ToInt32(IdPizza));
                    pizzas.Add(pizza);
                }

                pedido.Cliente =  await _clienteService.GetClienteById(pedido.IdCliente);
                pedido.Bebidas = bebidas;
                pedido.Pizzas = pizzas;
            }
            return _mapper.Map<PedidoVO>(pedido);
        }


        public async Task<PedidoVO> Create(PedidoVO vo)
        {
            Pedido pedidos = _mapper.Map<Pedido>(vo);
            PedidoPizza pedidoPizzas = new PedidoPizza();
            PedidoBebida pedidoBebidas = new PedidoBebida();

            pedidos.IdCliente = pedidos.Cliente.Id;
            pedidos.DataPedido = DateTime.Now;

            foreach (var bebida in pedidos.Bebidas)
            {
                pedidos.TotalPedido += bebida.Preco;
                pedidos.QtdBebidas++;
            }

            foreach (var pizza in pedidos.Pizzas)
            {
                pedidos.TotalPedido += pizza.Preco;
                pedidos.QtdPizza++;
            }

            _context.Pedidos.Add(pedidos);
            await _context.SaveChangesAsync();


            foreach (var bebida in pedidos.Bebidas)
            {
                pedidoBebidas.Id = 0;
                pedidoBebidas.IdPedido = pedidos.Id;
                pedidoBebidas.IdBebida = bebida.Id;
                _context.PedidoBebidas.Add(pedidoBebidas);
                await _context.SaveChangesAsync();

            }

            foreach (var pizza in pedidos.Pizzas)
            {
                pedidoPizzas.Id = 0;
                pedidoPizzas.IdPedido = pedidos.Id;
                pedidoPizzas.IdPizza = pizza.Id;
                _context.PedidoPizzas.Add(pedidoPizzas);
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<PedidoVO>(pedidos);
        }

        public async Task<PedidoVO> Update(PedidoVO vo)
        {
            Pedido pedido = _mapper.Map<Pedido>(vo);
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();

            return _mapper.Map<PedidoVO>(pedido);
        }


        public async Task<bool> Delete(int id)
        {

            var pedido = await _context.Pedidos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            List<PedidoPizza> pizzas = new List<PedidoPizza>();
            List<PedidoBebida> bebidas = new List<PedidoBebida>();


            if (pedido != null)
            {
                pizzas = await _context.PedidoPizzas.AsNoTracking().Where(b => b.IdPedido == pedido.Id).ToListAsync();
                if (pizzas != null)
                {
                    foreach (var pizza in pizzas)
                    {
                        _context.PedidoPizzas.Remove(pizza);
                        await _context.SaveChangesAsync();
                    }
                }

                bebidas = await _context.PedidoBebidas.AsNoTracking().Where(p => p.IdPedido == pedido.Id).ToListAsync();
                if (bebidas != null)
                {
                    foreach (var bebida in bebidas)
                    {
                        _context.PedidoBebidas.Remove(bebida);
                        await _context.SaveChangesAsync();
                    }
                }

                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }


    }
}
