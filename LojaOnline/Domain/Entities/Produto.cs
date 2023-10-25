using Domain.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Produto : BaseEntity
    {
        public int cd_produto { get; set; }
        public int id_categoria01 { get; set; }
        public int id_categoria02 { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public bool ativo { get; set; }
    }
    public class ListProduto
    {
        public List<Produto> produtos { get; set; }
    }
}
