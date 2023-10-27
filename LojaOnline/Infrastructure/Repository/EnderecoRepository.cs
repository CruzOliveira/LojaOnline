using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public EnderecoRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<Endereco>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Endereco> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Endereco>> SelectAsync(Endereco entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Endereco> CreateAsync(Endereco entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Endereco> UpdateAsync(Endereco entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Endereco> DeleteAsync(int code, int user)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {                    
                    dbConnection.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async Task<ListEndereco> CreateEnderecoAsync(ListEndereco entity)
        {
            var dynamic = new DynamicParameters();
            try
            {
                foreach (var item in entity.endereco)
                {
                    dynamic.Add("RUA", item.rua);
                    dynamic.Add("MODULO", item.modulo);
                    dynamic.Add("NIVEL", item.nivel);
                    dynamic.Add("POSICAO", item.posicao);

                    var result = await dbConnection.ExecuteAsync("LO_SP_ENDERECO_I", dynamic, commandType: CommandType.StoredProcedure);
                }
            }
            finally
            {
                dynamic = null;
            }
            return entity;
        }

        public Task<IEnumerable<Endereco>> ListEnderecoAsync(string rua, string modulo, string nivel, string posicao, string cdEndereco)
        {
            var dynamic = new DynamicParameters();
            var resultado = string.Empty;
            dynamic.Add("RUA", rua);
            dynamic.Add("MODULO", modulo);
            dynamic.Add("NIVEL", nivel);
            dynamic.Add("POSICAO", posicao);
            dynamic.Add("CD_ENDERECO", cdEndereco);

            return dbConnection.QueryAsync<Endereco>("LO_SP_ENDERECO_S", dynamic, commandType: CommandType.StoredProcedure);
        }
    }
}

