using Pizzaria.ClienteAPI.Model;
using Pizzaria.PizzaAPI.Model;

namespace Pizzaria.PedidoAPI.Model
{
    public class PedidoVO
    {
        public int Id { get; set; }

        public  DateTime  DataPedido{ get; set; }

        public int Status { get; set; }

        public int QtdPedido { get; set; }

        public decimal TotalPedido { get; set; }

        public int QtdBebidas { get; set; }

        public int QtdPizza { get; set; }

        public ClienteVO Cliente { get; set; }

        public List<PizzaVO> Pizzas { get; set; }

        public List<BebidaVO>  Bebidas { get; set; }



    }
}
