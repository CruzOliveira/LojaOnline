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
    public class ProdutoEanService : IProdutoEanService
    {
        public readonly IProdutoEanRepository infrastructure;
        private readonly IValidator<ProdutoEan> validator;
        private readonly RedisCacheExtensions cache;

        public ProdutoEanService(IDbConnection dbConnection, IValidator<ProdutoEan> validator, IDistributedCache cache)
        {
            infrastructure = new ProdutoEanRepository(dbConnection);
            this.validator = validator;
            this.cache = new RedisCacheExtensions(cache);
        }

        public async Task<Resultado<IEnumerable<ProdutoEan>>> ListAsync()
        {
            try
            {
                return Resultado<IEnumerable<ProdutoEan>>.ComSucesso(await this.infrastructure.ListAsync());
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<ProdutoEan>>.ComErros(null, Resultado<IEnumerable<ProdutoEan>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ProdutoEan>> GetAsync(int code)
        {
            try
            {
                return Resultado<ProdutoEan>.ComSucesso(await this.infrastructure.GetAsync(code));
            }
            catch (Exception exception)
            {
                return Resultado<ProdutoEan>.ComErros(null, Resultado<ProdutoEan>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<IEnumerable<ProdutoEan>>> SelectAsync(ProdutoEan entity)
        {
            try
            {
                return Resultado<IEnumerable<ProdutoEan>>.ComSucesso(await this.infrastructure.SelectAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<ProdutoEan>>.ComErros(null, Resultado<IEnumerable<ProdutoEan>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ProdutoEan>> CreateAsync(ProdutoEan entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<ProdutoEan>.ComErros(entity, errosValidacao);
                }

                return Resultado<ProdutoEan>.ComSucesso(await this.infrastructure.CreateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<ProdutoEan>.ComErros(null, Resultado<ProdutoEan>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ProdutoEan>> UpdateAsync(ProdutoEan entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<ProdutoEan>.ComErros(entity, errosValidacao);
                }

                return Resultado<ProdutoEan>.ComSucesso(await this.infrastructure.UpdateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<ProdutoEan>.ComErros(null, Resultado<ProdutoEan>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<ProdutoEan>> DeleteAsync(int code, int user)
        {
            try
            {
                return Resultado<ProdutoEan>.ComSucesso(await this.infrastructure.DeleteAsync(code, user));
            }
            catch (Exception exception)
            {
                return Resultado<ProdutoEan>.ComErros(null, Resultado<ProdutoEan>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Resultado<ListProdutoEan>> CreateEanAsync(ListProdutoEan entity)
        {
            try
            {
                return Resultado<ListProdutoEan>.ComSucesso(await this.infrastructure.CreateEanAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<ListProdutoEan>.ComErros(null, Resultado<ListProdutoEan>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }
    }
}
