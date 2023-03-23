using Microsoft.EntityFrameworkCore;
using Pizzaria.ClienteAPI.Model;
using Pizzaria.PedidoAPI.Model;
using System.Diagnostics;

namespace Pizzaria.PizzaAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { 
        
           
        }


        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<PedidoPizza> PedidoPizzas { get; set; }

        public DbSet<PedidoBebida> PedidoBebidas { get; set; }

    }
}
