using Domain.Base;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IEnderecoService : IService<Endereco>
    {
        Task<Resultado<ListEndereco>> CreateEnderecoAsync(ListEndereco entity);
        Task<Resultado<IEnumerable<Endereco>>> ListEnderecoAsync(string rua, string modulo, string nivel, string posicao, string cdEndereco);
    }
}
