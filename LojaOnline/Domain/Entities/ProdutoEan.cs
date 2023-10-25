using Domain.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ProdutoEan 
    {
        public int cd_produto { get; set; }
        public int ean { get; set; }
        public string tamanho { get; set; }
        public string cor { get; set; }
    }
    public class ListProdutoEan
    {
        public List<ProdutoEan> produtoEan { get; set; }
    }
}
