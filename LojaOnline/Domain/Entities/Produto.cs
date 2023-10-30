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

    public class Produtos
    {
        public int cd_produto { get; set; }
        public List<InfoProduto> infoproduto { get; set; }
    }

    public class InfoProduto
    {
        public string ean { get; set; }
        public string produto { get; set; }
        public string descricao { get; set; }
        public string cat_1 { get; set; }
        public string cat_2 { get; set; }
        public string cor { get; set; }
        public string tamanho { get; set; }
        public int ativo { get; set; }
    }

    public class ConsultaProduto
    {
        public List<Produtos> produto { get; set; }
    }
}
