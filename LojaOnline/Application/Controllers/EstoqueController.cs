using Application.AppData;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : Controller
    {
        private readonly IEstoqueService service;
        private readonly IMapper mapper;
        private readonly string chaveToken;

        public EstoqueController(IConfiguration configuration, IEstoqueService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
            this.chaveToken = configuration.GetSection("Seguranca:ChaveToken").Value;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(Domain.DTO.ListEstoque entityIn)
        {
            //var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
            //if (autenticacao == null)
            //    return Unauthorized();

            var entity = mapper.Map<ListEstoque>(entityIn);
            //entity.User = autenticacao.CodigoUsuario;

            var resultado = await service.CreateEstoqueAsync(entity);
            if (resultado.BadRequest)
                return new BadRequestObjectResult(resultado);

            return new ObjectResult(resultado.Conteudo);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id_loja, int? cd_produto)
        {
            //var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
            //if (autenticacao == null)
            //    return Unauthorized();

            var resultado = await service.GetEstoqueAsync(id_loja, cd_produto);
            if (resultado.BadRequest)
                return new BadRequestObjectResult(resultado);

            return new ObjectResult(resultado.Conteudo);
        }

        //[HttpGet]
        //public async Task<IActionResult> List()
        //{
        //    var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
        //    if (autenticacao == null)
        //        return Unauthorized();

        //    var resultado = await service.ListAsync();
        //    if (resultado.BadRequest)
        //        return new BadRequestObjectResult(resultado);

        //    return new ObjectResult(resultado.Conteudo);
        //}

        //// GET api/todo
        ///// <summary>
        ///// Obtém um(a) Estoque
        ///// </summary>
        //[HttpGet("{codigo}")]
        //public async Task<IActionResult> Get(int codigo)
        //{
        //    var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
        //    if (autenticacao == null)
        //        return Unauthorized();

        //    var resultado = await service.GetAsync(codigo);
        //    if (resultado.BadRequest)
        //        return new BadRequestObjectResult(resultado);

        //    return new ObjectResult(resultado.Conteudo);
        //}

        //// PATCH api/todo
        ///// <summary>
        ///// Retorna uma lista de Estoque
        ///// </summary>
        //[HttpPatch]
        //public async Task<IActionResult> Select(Domain.DTO.Estoque entityIn)
        //{
        //    var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
        //    if (autenticacao == null)
        //        return Unauthorized();

        //    var entity = mapper.Map<Estoque>(entityIn);

        //    var resultado = await service.SelectAsync(entity);
        //    if (resultado.BadRequest)
        //        return new BadRequestObjectResult(resultado);

        //    return new ObjectResult(resultado.Conteudo);
        //}

        //// POST api/todo
        ///// <summary>
        ///// Cria um(a) novo(a) Estoque
        ///// </summary>
        //[HttpPost]
        //public async Task<IActionResult> Create(Domain.DTO.Estoque entityIn)
        //{
        //    var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
        //    if (autenticacao == null)
        //        return Unauthorized();

        //    var entity = mapper.Map<Estoque>(entityIn);
        //    entity.User = autenticacao.CodigoUsuario;

        //    var resultado = await service.CreateAsync(entity);
        //    if (resultado.BadRequest)
        //        return new BadRequestObjectResult(resultado);

        //    return new ObjectResult(resultado.Conteudo);
        //}


        //// PUT api/todo
        ///// <summary>
        ///// Altera um(a) novo(a) Estoque
        ///// </summary>
        //[HttpPut]
        //public async Task<IActionResult> Update(Domain.DTO.Estoque entityIn)
        //{
        //    var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
        //    if (autenticacao == null)
        //        return Unauthorized();

        //    var entity = mapper.Map<Estoque>(entityIn);
        //    entity.User = autenticacao.CodigoUsuario;

        //    var resultado = await service.UpdateAsync(entity);
        //    if (resultado.BadRequest)
        //        return new BadRequestObjectResult(resultado);

        //    return new ObjectResult(resultado.Conteudo);
        //}

        //// DELETE api/todo
        ///// <summary>
        ///// Exclui um(a) Estoque
        ///// </summary>
        //[HttpDelete]
        //public async Task<IActionResult> Delete(int codigo)
        //{
        //    var autenticacao = Utils.ValidaToken(User.Claims, this.chaveToken);
        //    if (autenticacao == null)
        //        return Unauthorized();

        //    var resultado = await service.DeleteAsync(codigo, (int)autenticacao.CodigoUsuario);
        //    if (resultado.BadRequest)
        //        return new BadRequestObjectResult(resultado);

        //    return new ObjectResult(resultado.Conteudo);
        //}
    }
}
