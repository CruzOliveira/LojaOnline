using Domain.Base;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using FluentValidation;
using Infrastructure.Repository;
using Microsoft.Extensions.Caching.Distributed;
using Service.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EstoqueService : IEstoqueService
    {
        public readonly IEstoqueRepository infrastructure;
        private readonly IValidator<Estoque> validator;
        private readonly RedisCacheExtensions cache;

        public EstoqueService(IDbConnection dbConnection, IValidator<Estoque> validator, IDistributedCache cache)
        {
            infrastructure = new EstoqueRepository(dbConnection);
            this.validator = validator;
            this.cache = new RedisCacheExtensions(cache);
        }

        public async Task<Resultado<IEnumerable<Estoque>>> ListAsync()
        {
            try
            {
                return Resultado<IEnumerable<Estoque>>.ComSucesso(await this.infrastructure.ListAsync());
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<Estoque>>.ComErros(null, Resultado<IEnumerable<Estoque>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Estoque>> GetAsync(int code)
        {
            try
            {
                return Resultado<Estoque>.ComSucesso(await this.infrastructure.GetAsync(code));
            }
            catch (Exception exception)
            {
                return Resultado<Estoque>.ComErros(null, Resultado<Estoque>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<IEnumerable<Estoque>>> SelectAsync(Estoque entity)
        {
            try
            {
                return Resultado<IEnumerable<Estoque>>.ComSucesso(await this.infrastructure.SelectAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<Estoque>>.ComErros(null, Resultado<IEnumerable<Estoque>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Estoque>> CreateAsync(Estoque entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<Estoque>.ComErros(entity, errosValidacao);
                }

                return Resultado<Estoque>.ComSucesso(await this.infrastructure.CreateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<Estoque>.ComErros(null, Resultado<Estoque>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Estoque>> UpdateAsync(Estoque entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<Estoque>.ComErros(entity, errosValidacao);
                }

                return Resultado<Estoque>.ComSucesso(await this.infrastructure.UpdateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<Estoque>.ComErros(null, Resultado<Estoque>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Estoque>> DeleteAsync(int code, int user)
        {
            try
            {
                return Resultado<Estoque>.ComSucesso(await this.infrastructure.DeleteAsync(code, user));
            }
            catch (Exception exception)
            {
                return Resultado<Estoque>.ComErros(null, Resultado<Estoque>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Resultado<ListEstoque>> CreateEstoqueAsync(ListEstoque entity)
        {
            try
            {
                return Resultado<ListEstoque>.ComSucesso(await this.infrastructure.CreateEstoqueAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<ListEstoque>.ComErros(null, Resultado<ListEstoque>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ConsultaEstoque>> GetEstoqueAsync(int idLoja, int? cdProduto, int? cdEndereco)
        {
            try
            {
                return Resultado<ConsultaEstoque>.ComSucesso(await this.infrastructure.GetEstoqueAsync(idLoja, cdProduto, cdEndereco));
            }
            catch (Exception exception)
            {
                return Resultado<ConsultaEstoque>.ComErros(null, Resultado<ListEstoque>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }
    }
}   
