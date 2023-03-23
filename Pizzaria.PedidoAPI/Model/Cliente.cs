using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaria.ClienteAPI.Model
{
    [NotMapped]
    public class Cliente
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Cpf { get; set; }
    }
}
