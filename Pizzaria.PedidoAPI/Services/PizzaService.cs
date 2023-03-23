using Pizzaria.PedidoAPI.Model.ViewModel;
using Pizzaria.PedidoAPI.Services.IServices;
using System.Net.Http.Headers;
using System.Net;
using Pizzaria.PedidoAPI.Utils;
using Pizzaria.PizzaAPI.Model;

namespace Pizzaria.PedidoAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/Pizza";

        public PizzaService(HttpClient client)
        {
            _client = client ?? throw new ArgumentException(nameof(client));
        }
         
        public async Task<Pizza> GetPizzaById(int id)
        {
            var response = await _client.GetAsync($"{BasePath}/find-by-id/{id}");
            if (response.StatusCode != HttpStatusCode.OK) return new Pizza();
            return await response.ReadContentAs<Pizza>();
        }
    }
    
}

