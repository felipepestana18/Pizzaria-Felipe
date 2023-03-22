using Pizzaria.PedidoAPI.Model.ViewModel;

namespace Pizzaria.PedidoAPI.Services.IServices
{
    public interface IPizzaService
    {
        Task<PizzaViewModel> GetPizzaById(int id);
    }
}
