using Pizzaria.PizzaAPI.Data.ValueObjects;

namespace Pizzaria.PizzaAPI.Repository
{
    public interface  IPizzaRepository
    {
        //para retorna uma lista de produtos
        Task<PizzaVO> FindById(int id);

        Task<IEnumerable<PizzaVO>> FindAll();

        Task<PizzaVO> Create(PizzaVO vo);

        Task<PizzaVO> Update(PizzaVO vo);

        Task<bool> Delete(int id);
    }
}
