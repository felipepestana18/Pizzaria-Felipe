using Pizzaria.ClienteAPI.Model;
using Pizzaria.PedidoAPI.Model.ViewModel;

namespace Pizzaria.PedidoAPI.Services.IServices
{
    public interface IClienteService
    {
        Task<Cliente> GetClienteById(int id);
    }
}
