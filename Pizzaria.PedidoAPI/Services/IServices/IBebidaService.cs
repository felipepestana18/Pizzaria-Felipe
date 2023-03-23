using Pizzaria.PedidoAPI.Model;
using Pizzaria.PedidoAPI.Model.ViewModel;

namespace Pizzaria.PedidoAPI.Services.IServices
{

    public interface IBebidaService
    {
        Task<Bebida> GetBebidaById(int id);
    }

}
