using Domain.Base;
using System.Collections.Generic;

namespace Domain.DTO
{
    public class Endereco 
    {
        
        public int idEndereco { get; set; }
        public string rua { get; set; }
        public string modulo { get; set; }
        public string nivel { get; set; }
        public string posicao { get; set; }
        public string cdEndereco { get; set; }

    }
    public class ListEndereco 
    {
        public List<Endereco> endereco { get; set; }
    }
}
