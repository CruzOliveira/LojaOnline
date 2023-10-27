using Domain.Base;

namespace Domain.Entities
{
    public class Categoria02 : BaseEntity
    {
        public int idCategoria02 { get; set; }
        public string nome { get; set; }
        public int idCategoria01 { get; set; }
    }
}
