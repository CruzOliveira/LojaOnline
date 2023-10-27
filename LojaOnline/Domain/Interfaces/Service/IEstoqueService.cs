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
        Task<Resultado<ConsultaEstoque>> GetEstoqueAsync(int idLoja, int? cdProduto, int? cdEndereco);
    }
}
