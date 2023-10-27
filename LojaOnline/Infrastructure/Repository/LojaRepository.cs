using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class LojaRepository : ILojaRepository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public LojaRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<Loja>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Loja> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Loja>> SelectAsync(Loja entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Loja> CreateAsync(Loja entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Loja> UpdateAsync(Loja entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Loja> DeleteAsync(int code, int user)
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

        public async Task<Loja> CreateLojaAsync(string nome)
        {
            var dynamic = new DynamicParameters();
            try 
            {
                dynamic.Add("NOME", nome);
  
                var result = await dbConnection.ExecuteScalarAsync<Loja>("LO_SP_LOJA_I", dynamic, commandType: CommandType.StoredProcedure);
               
                return result;
            }
            finally
            {
                dynamic = null;
            }

        }
    }
}
