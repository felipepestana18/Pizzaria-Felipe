using AutoMapper;
using Pizzaria.PedidoAPI.Model;

namespace Pizzaria.PedidoAPI.Repository
{
    public interface IPedidoRepository
    {


        Task<IEnumerable<PedidoVO>> GetAll();

        Task<PedidoVO> GetById(int id);

        Task<PedidoVO> Create(PedidoVO vo);

        Task<PedidoVO> Update(PedidoVO vo);

        Task<PedidoVO> Delete(int id);

    }
}
