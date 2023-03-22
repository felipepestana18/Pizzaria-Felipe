using Pizzaria.PedidoAPI.Model.ViewModel;

namespace Pizzaria.PedidoAPI.Services.IServices
{

    public interface IBebidaService
    {
        Task<BebidaViewModel> GetBebidaById(int id);
    }

}
