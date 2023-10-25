using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IProdutoEanRepository: IRepository<ProdutoEan>
    {
        Task<ListProdutoEan> CreateEanAsync(ListProdutoEan entity);
    }
}
