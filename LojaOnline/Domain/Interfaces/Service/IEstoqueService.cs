using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IEstoqueService : IService<Estoque>
    {
        Task<Resultado<ListEstoque>> CreateEstoqueAsync(ListEstoque entity);
        Task<Resultado<Root>> GetEstoqueAsync(int id_loja, int? cd_produto);
    }
}
