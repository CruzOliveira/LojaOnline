using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IProdutoEanService : IService<ProdutoEan>
    {
        Task<Resultado<ListProdutoEan>> CreateEanAsync(ListProdutoEan entity);
    }
}
