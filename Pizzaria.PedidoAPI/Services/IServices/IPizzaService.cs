using Pizzaria.PedidoAPI.Model.ViewModel;
using Pizzaria.PizzaAPI.Model;

namespace Pizzaria.PedidoAPI.Services.IServices
{
    public interface IPizzaService
    {
        Task<Pizza> GetPizzaById(int id);
    }
}
