using Domain.Base;
using System.Collections.Generic;

namespace Domain.DTO
{
    public class ProdutoEan 
    {
        public int cdProduto { get; set; }
        public string ean { get; set; }
        public string tamanho { get; set; }
        public string cor { get; set; }
    }
    public class ListProdutoEan
    {
        public List<ProdutoEan> produtoEan { get; set; }
    }
}
