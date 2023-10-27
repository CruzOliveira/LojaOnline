using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IEnderecoRepository: IRepository<Endereco>
    {
        Task<ListEndereco> CreateEnderecoAsync(ListEndereco entity);
        Task<IEnumerable<Endereco>> ListEnderecoAsync(string rua, string modulo, string nivel, string posicao, string cdEndereco);
    }
}
