using Domain.Base;
using System.Collections.Generic;

namespace Domain.DTO
{
    public class Produto 
    {
        public int cdProduto { get; set; }
        public int idCategoria01 { get; set; }
        public int idCategoria02 { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public bool ativo { get; set; }
    }
    public class ListProduto
    {
        public List<Produto> produtos { get; set; }
    }
}
