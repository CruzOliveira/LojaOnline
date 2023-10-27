using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IEstoqueRepository: IRepository<Estoque>
    {
        Task<ListEstoque> CreateEstoqueAsync(ListEstoque entity);
        Task<ConsultaEstoque> GetEstoqueAsync(int idLoja, int? cdProduto, int? cdEndereco);
    }
}
