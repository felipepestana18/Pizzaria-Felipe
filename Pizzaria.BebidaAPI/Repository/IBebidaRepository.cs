using Pizzaria.BebidaAPI.Data.ValueObjects;

namespace Pizzaria.BebidaAPI.Repository
{
    public interface IBebidaRepository
    {
        Task<BebidaVO> GetById(int id);

        Task<IEnumerable<BebidaVO>> GetAll();

        Task<BebidaVO> Create (BebidaVO vo);
        
        Task<BebidaVO> Update (BebidaVO vo);

        Task<bool> Delete (int id);
    }
}
