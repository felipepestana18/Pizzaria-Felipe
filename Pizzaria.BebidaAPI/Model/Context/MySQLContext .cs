
using Microsoft.EntityFrameworkCore;

namespace Pizzaria.BebidaAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Bebida> Bebidas { get; set; }

    }
}
