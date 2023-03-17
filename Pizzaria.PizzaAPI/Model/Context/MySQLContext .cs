using Microsoft.EntityFrameworkCore;

namespace Pizzaria.PizzaAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }

    }
}
