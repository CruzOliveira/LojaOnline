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
    public class Categoria02Service : ICategoria02Service
    {
        public readonly ICategoria02Repository infrastructure;
        private readonly IValidator<Categoria02> validator;
        private readonly RedisCacheExtensions cache;

        public Categoria02Service(IDbConnection dbConnection, IValidator<Categoria02> validator, IDistributedCache cache)
        {
            infrastructure = new Categoria02Repository(dbConnection);
            this.validator = validator;
            this.cache = new RedisCacheExtensions(cache);
        }

        public async Task<Resultado<IEnumerable<Categoria02>>> ListAsync()
        {
            try
            {
                return Resultado<IEnumerable<Categoria02>>.ComSucesso(await this.infrastructure.ListAsync());
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<Categoria02>>.ComErros(null, Resultado<IEnumerable<Categoria02>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Categoria02>> GetAsync(int code)
        {
            try
            {
                return Resultado<Categoria02>.ComSucesso(await this.infrastructure.GetAsync(code));
            }
            catch (Exception exception)
            {
                return Resultado<Categoria02>.ComErros(null, Resultado<Categoria02>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<IEnumerable<Categoria02>>> SelectAsync(Categoria02 entity)
        {
            try
            {
                return Resultado<IEnumerable<Categoria02>>.ComSucesso(await this.infrastructure.SelectAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<Categoria02>>.ComErros(null, Resultado<IEnumerable<Categoria02>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Categoria02>> CreateAsync(Categoria02 entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<Categoria02>.ComErros(entity, errosValidacao);
                }

                return Resultado<Categoria02>.ComSucesso(await this.infrastructure.CreateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<Categoria02>.ComErros(null, Resultado<Categoria02>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Categoria02>> UpdateAsync(Categoria02 entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<Categoria02>.ComErros(entity, errosValidacao);
                }

                return Resultado<Categoria02>.ComSucesso(await this.infrastructure.UpdateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<Categoria02>.ComErros(null, Resultado<Categoria02>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Categoria02>> DeleteAsync(int code, int user)
        {
            try
            {
                return Resultado<Categoria02>.ComSucesso(await this.infrastructure.DeleteAsync(code, user));
            }
            catch (Exception exception)
            {
                return Resultado<Categoria02>.ComErros(null, Resultado<Categoria02>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Resultado<Categoria02>> CreateCategoriaAsync(string nome, int id_categoria01)
        {
            try
            {
                return Resultado<Categoria02>.ComSucesso(await this.infrastructure.CreateCategoriaAsync(nome, id_categoria01));
            }
            catch (Exception exception)
            {
                return Resultado<Categoria02>.ComErros(null, Resultado<Categoria02>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }
    }
}
