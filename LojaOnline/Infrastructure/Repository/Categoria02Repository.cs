using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class Categoria02Repository : ICategoria02Repository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public Categoria02Repository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<Categoria02>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Categoria02> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Categoria02>> SelectAsync(Categoria02 entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Categoria02> CreateAsync(Categoria02 entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Categoria02> UpdateAsync(Categoria02 entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Categoria02> DeleteAsync(int code, int user)
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

        public async Task<Categoria02> CreateCategoriaAsync(string nome, int idCategoria01)
        {
            var dynamic = new DynamicParameters();
            Categoria02 retorno = new Categoria02();
            try
            {
                dynamic.Add("NOME", nome);
                dynamic.Add("ID_CATEGORIA01", idCategoria01);

                var result = await dbConnection.ExecuteAsync("LO_SP_CATEGORIA02_I", dynamic, commandType: CommandType.StoredProcedure);

                return retorno;
            }
            finally
            {
                dynamic = null;
            }
        }
    }
}
