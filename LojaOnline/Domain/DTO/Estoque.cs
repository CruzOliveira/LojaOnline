using Domain.Base;
using System.Collections.Generic;

namespace Domain.DTO
{
    public class Estoque
    {
        public string ean { get; set; }
        public decimal preco { get; set; }
        public int idLoja { get; set; }
        public int idEndereco { get; set; }
        public decimal quantidade { get; set; }
    }

    public class ListEstoque
    {
        public List<Estoque> estoque { get; set; }
    }
}
