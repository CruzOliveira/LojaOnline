using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface ICategoria02Repository: IRepository<Categoria02>
    {
        Task<Categoria02> CreateCategoriaAsync(string nome, int id_categoria01);
    }
}
