using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface ILojaRepository: IRepository<Loja>
    {
        Task<Loja> CreateLojaAsync(string nome);
    }
}
