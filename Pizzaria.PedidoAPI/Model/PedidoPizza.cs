using Pizzaria.PizzaAPI.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaria.PedidoAPI.Model
{
    public class PedidoPizza
    {
        [Key]
        public int Id { get; set; }

        public int IdPedido { get; set; }

        public int IdPizza { get; set; } 
    }
}
