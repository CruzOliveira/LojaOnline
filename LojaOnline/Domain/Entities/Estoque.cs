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
    public class EstoqueC
    {
        public string loja { get; set; }
        public List<ProdutoE> produto { get; set; }
    }

    public class InfoProdutoE
    {
        public string produto { get; set; }
        public string descricao { get; set; }
        public string cat2 { get; set; }
        public string cat1 { get; set; }
        public string cor { get; set; }
        public string tamanho { get; set; }
        public List<QuatidadePreco> quantidadePreco { get; set; }
    }

    public class ProdutoE
    {
        public int cdProduto { get; set; }
        public string cdEdereco { get; set; }
        public string ean { get; set; }
        public List<InfoProdutoE> InfoProduto { get; set; }
    }

    public class QuatidadePreco
    {
        public double preco { get; set; }
        public int quantidade { get; set; }
    }

    public class ConsultaEstoque
    {
        public List<EstoqueC> estoque { get; set; }
    }


}

