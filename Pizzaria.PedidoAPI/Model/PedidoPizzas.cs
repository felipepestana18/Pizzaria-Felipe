using System.ComponentModel.DataAnnotations;

namespace Pizzaria.PedidoAPI.Model
{
    public class PedidoPizzas
    {
        [Key]
        public int IdPedido { get; set; }

        public int IdPizza { get; set; } 
    }
}
