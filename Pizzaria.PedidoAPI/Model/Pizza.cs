using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaria.PizzaAPI.Model
{
    [NotMapped]
    public class Pizza
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }
    }
}
