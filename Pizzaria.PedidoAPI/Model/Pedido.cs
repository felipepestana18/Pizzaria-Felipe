using Pizzaria.ClienteAPI.Model;
using Pizzaria.PizzaAPI.Model;

namespace Pizzaria.PedidoAPI.Model
{
    public class Pedido
    {
        public int Id { get; set; }

        public  DateTime  DataPedido{ get; set; }

        public int Status { get; set; }

        public int QtdPedido { get; set; }

        public decimal TotalPedido { get; set; }

        public int QtdBebidas { get; set; }

        public int QtdPizza { get; set; }


        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }

        public List<Pizza> Pizzas { get; set; }

        public List<Bebida>  Bebidas { get; set; }


    }
}
