using AutoMapper;
using Domain.Entities;

namespace Application.AppData
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Domain.DTO.Produto, Produto>();
            this.CreateMap<Domain.DTO.Endereco, Endereco>();
            this.CreateMap<Domain.DTO.ProdutoEan, ProdutoEan>();
            this.CreateMap<Domain.DTO.Estoque, Estoque>();
            this.CreateMap<Domain.DTO.ListProduto, ListProduto>();
            this.CreateMap<Domain.DTO.ListEstoque, ListEstoque>();
            this.CreateMap<Domain.DTO.ListProdutoEan, ListProdutoEan>();
            this.CreateMap<Domain.DTO.ListEndereco, ListEndereco>();
        }
    }
}
