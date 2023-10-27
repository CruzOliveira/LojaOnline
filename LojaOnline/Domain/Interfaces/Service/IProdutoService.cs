using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IProdutoService : IService<Produto>
    {
        Task<Resultado<ListProduto>> CreateProdutoAsync(ListProduto entity);
        Task<Resultado<ConsultaProduto>> GetProdutoAsync(int? cdProduto, string ean);
    }
}
