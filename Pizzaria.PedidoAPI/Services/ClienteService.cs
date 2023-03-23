using Pizzaria.ClienteAPI.Model;
using Pizzaria.PedidoAPI.Model.ViewModel;
using Pizzaria.PedidoAPI.Services.IServices;
using Pizzaria.PedidoAPI.Utils;
using System.Net;

namespace Pizzaria.PedidoAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/Cliente";

        public ClienteService(HttpClient client)
        {
            _client = client ?? throw new ArgumentException(nameof(client));
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            var response = await _client.GetAsync($"{BasePath}/find-by-id/{id}");
            if (response.StatusCode != HttpStatusCode.OK) return new Cliente();
            return await response.ReadContentAs<Cliente>();
        }
    }
}
