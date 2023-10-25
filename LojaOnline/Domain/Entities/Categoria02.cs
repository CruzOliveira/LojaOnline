using Domain.Base;

namespace Domain.Entities
{
    public class Categoria02 : BaseEntity
    {
        public int id_categoria02 { get; set; }
        public string nome { get; set; }
        public int id_categoria01 { get; set; }
    }
}
