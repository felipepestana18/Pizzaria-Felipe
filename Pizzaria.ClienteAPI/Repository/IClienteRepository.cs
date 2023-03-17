using Pizzaria.ClienteAPI.Data.ValueObject;

namespace Pizzaria.ClienteAPI.Repository
{
    public interface IClienteRepository 
    {

       Task<IEnumerable<ClienteVO>> GetAll();

       Task<ClienteVO> GetById(int id);

       Task<ClienteVO> Create(ClienteVO vo);

       Task<ClienteVO> Update(ClienteVO vo);

       Task<bool> Delete(int id);
    }
}
