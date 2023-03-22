using Pizzaria.PedidoAPI.Model.ViewModel;

namespace Pizzaria.PedidoAPI.Services.IServices
{
    public class IClienteService
    {
        public interface IPizzaService
        {
            Task<ClienteViewModel> GetClienteById(int id);
        }
    }
}
