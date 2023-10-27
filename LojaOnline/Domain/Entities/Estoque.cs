using Domain.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Estoque : BaseEntity
    {

        public int idEndereco { get; set; }
        public string ean { get; set; }
        public decimal preco { get; set; }
        public int idLoja { get; set; }
        public decimal quantidade { get; set; }
        public string produto { get; set; }
        public string cat1 { get; set; }
        public string cat2 { get; set; }
    }

    public class ListEstoque
    {
        public List<Estoque> estoque { get; set; }
    }
    public class INFOPRODUTOESTOQUE
    {
        public double preco { get; set; }
        public int quantidade { get; set; }
    }

    public class LOJA
    {
        public string loja { get; set; }
        public List<PRODUTO> produto { get; set; }
    }

    public class PRODUTOESTOQUE
    {
        public int cdProduto { get; set; }
        public int cdEndereco { get; set; }
        public string end { get; set; }
        public string cat1 { get; set; }
        public string cat2 { get; set; }
        public string tamanho { get; set; }
        public string cor { get; set; }
        public string produto { get; set; }
        public string descricao { get; set; }
        public List<INFOPRODUTO> infoproduto { get; set; }
    }

    public class ConsultaEstoque
    {
        public List<LOJA> loja { get; set; }
    }
}

