using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaria.PedidoAPI.Model
{
    public class PedidoBebida
    {
        [Key]
        public int Id { get; set; } 

        public int IdBebida { get; set; }

        public int IdPedido { get; set; }

    }
}
