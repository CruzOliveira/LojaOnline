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
    public class LojaService : ILojaService
    {
        public readonly ILojaRepository infrastructure;
        private readonly IValidator<Loja> validator;
        private readonly RedisCacheExtensions cache;

        public LojaService(IDbConnection dbConnection, IValidator<Loja> validator, IDistributedCache cache)
        {
            infrastructure = new LojaRepository(dbConnection);
            this.validator = validator;
            this.cache = new RedisCacheExtensions(cache);
        }

        public async Task<Resultado<IEnumerable<Loja>>> ListAsync()
        {
            try
            {
                return Resultado<IEnumerable<Loja>>.ComSucesso(await this.infrastructure.ListAsync());
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<Loja>>.ComErros(null, Resultado<IEnumerable<Loja>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Loja>> GetAsync(int code)
        {
            try
            {
                return Resultado<Loja>.ComSucesso(await this.infrastructure.GetAsync(code));
            }
            catch (Exception exception)
            {
                return Resultado<Loja>.ComErros(null, Resultado<Loja>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<IEnumerable<Loja>>> SelectAsync(Loja entity)
        {
            try
            {
                return Resultado<IEnumerable<Loja>>.ComSucesso(await this.infrastructure.SelectAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<Loja>>.ComErros(null, Resultado<IEnumerable<Loja>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Loja>> CreateAsync(Loja entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<Loja>.ComErros(entity, errosValidacao);
                }

                return Resultado<Loja>.ComSucesso(await this.infrastructure.CreateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<Loja>.ComErros(null, Resultado<Loja>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Loja>> UpdateAsync(Loja entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<Loja>.ComErros(entity, errosValidacao);
                }

                return Resultado<Loja>.ComSucesso(await this.infrastructure.UpdateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<Loja>.ComErros(null, Resultado<Loja>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Loja>> DeleteAsync(int code, int user)
        {
            try
            {
                return Resultado<Loja>.ComSucesso(await this.infrastructure.DeleteAsync(code, user));
            }
            catch (Exception exception)
            {
                return Resultado<Loja>.ComErros(null, Resultado<Loja>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Resultado<Loja>> CreateLojaAsync(string nome)
        {
            try
            {
                return Resultado<Loja>.ComSucesso(await this.infrastructure.CreateLojaAsync(nome));
            }
            catch (Exception exception)
            {
                return Resultado<Loja>.ComErros(null, Resultado<Loja>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }
    }
}
