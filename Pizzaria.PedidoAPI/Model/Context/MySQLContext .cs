using Microsoft.EntityFrameworkCore;
using Pizzaria.ClienteAPI.Model;
using Pizzaria.PedidoAPI.Model;
using System.Diagnostics;

namespace Pizzaria.PizzaAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }


        public DbSet<Pedido> Pedidos { get; set; }  

        public DbSet<Bebida> Bebidas { get; set; }

        public DbSet<Cliente> Clientes { get; }

        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<PedidoPizzas> PedidoPizzas { get; }

        public DbSet<PedidoBebidas> PedidoBebidas { get; set; }

    }
}
