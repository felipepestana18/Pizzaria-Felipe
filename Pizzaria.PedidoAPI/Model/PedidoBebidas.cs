using System.ComponentModel.DataAnnotations;

namespace Pizzaria.PedidoAPI.Model
{
    public class PedidoBebidas
    {
        [Key]
        public int IdBebida { get; set; }
     
        public int IdPedido { get; set; }

    }
}
