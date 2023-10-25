using Domain.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Estoque : BaseEntity
    {

        public int id_estoque { get; set; }
        public int ean { get; set; }
        public decimal preco { get; set; }
        public int id_loja { get; set; }
        public decimal quantidade { get; set; }
        public string produto { get; set; }
        public string cat_1 { get; set; }
        public string cat_2 { get; set; }
    }

    public class ListEstoque
    {
        public List<Estoque> estoque { get; set; }
    }
    public class INFOPRODUTO
    {
        public double preco { get; set; }
        public int quantidade { get; set; }
    }

    public class LOJA
    {
        public string loja { get; set; }
        public List<PRODUTO> produto { get; set; }
    }

    public class PRODUTO
    {
        public int cd_produto { get; set; }
        public int end { get; set; }
        public string cat_1 { get; set; }
        public string cat_2 { get; set; }
        public string tamanho { get; set; }
        public string cor { get; set; }
        public string produto { get; set; }
        public string descricao { get; set; }
        public List<INFOPRODUTO> infoproduto { get; set; }
    }

    public class Root
    {
        public List<LOJA> loja { get; set; }
    }
}

