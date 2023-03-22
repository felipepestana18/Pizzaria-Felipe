using Pizzaria.PedidoAPI.Model.ViewModel;
using Pizzaria.PedidoAPI.Services.IServices;
using Pizzaria.PedidoAPI.Utils;
using System.Net;

namespace Pizzaria.PedidoAPI.Services
{
    public class BebidaService : IBebidaService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/Bebida";

        public BebidaService(HttpClient client)
        {
            _client = client ?? throw new ArgumentException(nameof(client));
        }

        public async Task<BebidaViewModel> GetBebidaById(int id)
        {
            var response = await _client.GetAsync($"{BasePath}/find-by-id/{id}");
            if (response.StatusCode != HttpStatusCode.OK) return new BebidaViewModel();
            return await response.ReadContentAs<BebidaViewModel>();
        }
    }
}

