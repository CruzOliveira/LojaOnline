using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface ILojaService : IService<Loja>
    {
        Task<Resultado<Loja>>CreateLojaAsync(string nome);
    }
}
