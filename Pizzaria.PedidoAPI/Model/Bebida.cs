using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaria.PedidoAPI.Model
{
    [NotMapped]
    public class Bebida
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Fornecedor {  get;  set; }

        public decimal Preco { get; set; }
    }
}
