using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface ICategoria02Service : IService<Categoria02>
    {
        Task<Resultado<Categoria02>> CreateCategoriaAsync(string nome, int id_categoria01);
    }
}
