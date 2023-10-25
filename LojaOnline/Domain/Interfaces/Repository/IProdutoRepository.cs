using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IProdutoRepository: IRepository<Produto>
    {
        Task<ListProduto> CreateProdutoAsync(ListProduto entity);
    }
}
