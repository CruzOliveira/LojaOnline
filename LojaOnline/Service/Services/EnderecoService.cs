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
    public class EnderecoService : IEnderecoService
    {
        public readonly IEnderecoRepository infrastructure;
        private readonly IValidator<Endereco> validator;
        private readonly RedisCacheExtensions cache;

        public EnderecoService(IDbConnection dbConnection, IValidator<Endereco> validator, IDistributedCache cache)
        {
            infrastructure = new EnderecoRepository(dbConnection);
            this.validator = validator;
            this.cache = new RedisCacheExtensions(cache);
        }

        public async Task<Resultado<IEnumerable<Endereco>>> ListAsync()
        {
            try
            {
                return Resultado<IEnumerable<Endereco>>.ComSucesso(await this.infrastructure.ListAsync());
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<Endereco>>.ComErros(null, Resultado<IEnumerable<Endereco>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Endereco>> GetAsync(int code)
        {
            try
            {
                return Resultado<Endereco>.ComSucesso(await this.infrastructure.GetAsync(code));
            }
            catch (Exception exception)
            {
                return Resultado<Endereco>.ComErros(null, Resultado<Endereco>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<IEnumerable<Endereco>>> SelectAsync(Endereco entity)
        {
            try
            {
                return Resultado<IEnumerable<Endereco>>.ComSucesso(await this.infrastructure.SelectAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<Endereco>>.ComErros(null, Resultado<IEnumerable<Endereco>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Endereco>> CreateAsync(Endereco entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<Endereco>.ComErros(entity, errosValidacao);
                }

                return Resultado<Endereco>.ComSucesso(await this.infrastructure.CreateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<Endereco>.ComErros(null, Resultado<Endereco>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Endereco>> UpdateAsync(Endereco entity)
        {
            try
            {
                var resultadoValidacao = validator.Validate(entity);
                if (!resultadoValidacao.IsValid)
                {
                    var errosValidacao = resultadoValidacao.Errors.Select(e => Error.Criar(e.PropertyName, e.ErrorMessage, TipoErro.Validacao, e.AttemptedValue)).ToList();
                    return Resultado<Endereco>.ComErros(entity, errosValidacao);
                }

                return Resultado<Endereco>.ComSucesso(await this.infrastructure.UpdateAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<Endereco>.ComErros(null, Resultado<Endereco>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<Endereco>> DeleteAsync(int code, int user)
        {
            try
            {
                return Resultado<Endereco>.ComSucesso(await this.infrastructure.DeleteAsync(code, user));
            }
            catch (Exception exception)
            {
                return Resultado<Endereco>.ComErros(null, Resultado<Endereco>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Resultado<ListEndereco>> CreateEnderecoAsync(ListEndereco entity)
        {
            try
            {
                return Resultado<ListEndereco>.ComSucesso(await this.infrastructure.CreateEnderecoAsync(entity));
            }
            catch (Exception exception)
            {
                return Resultado<ListEndereco>.ComErros(null, Resultado<ListEndereco>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }

        public async Task<Resultado<IEnumerable<Endereco>>> ListEnderecoAsync(string rua, string modulo, string nivel, string posicao, string cdEndereco)
        {
            try
            {
                return Resultado<IEnumerable<Endereco>>.ComSucesso(await this.infrastructure.ListEnderecoAsync(rua, modulo,  nivel,  posicao, cdEndereco));
            }
            catch (Exception exception)
            {
                return Resultado<IEnumerable<Endereco>>.ComErros(null, Resultado<IEnumerable<Endereco>>.AdicionarErro(Error.Criar(string.Empty, $"{exception}", TipoErro.Excecao, null)));
            }
        }
    }
}
