using Domain.Base;
using System.Collections.Generic;

namespace Domain.DTO
{
    public class Estoque
    {
        public int ean { get; set; }
        public decimal preco { get; set; }
        public int id_loja { get; set; }
        public decimal quantidade { get; set; }
    }

    public class ListEstoque
    {
        public List<Estoque> estoque { get; set; }
    }
}
