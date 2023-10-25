using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProdutoEanRepository : IProdutoEanRepository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public ProdutoEanRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<ProdutoEan>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProdutoEan> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProdutoEan>> SelectAsync(ProdutoEan entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ProdutoEan> CreateAsync(ProdutoEan entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ProdutoEan> UpdateAsync(ProdutoEan entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ProdutoEan> DeleteAsync(int code, int user)
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

        public  async Task<ListProdutoEan> CreateEanAsync(ListProdutoEan entity)
        {
            var dynamic = new DynamicParameters();

            try
            {
                foreach (var item in entity.produtoEan)
                {
                    dynamic.Add("CD_PRODUTO", item.cd_produto);
                    dynamic.Add("EAN", item.ean);
                    dynamic.Add("TAMANHO", item.tamanho);
                    dynamic.Add("COR", item.cor);
             
                    var result = await dbConnection.ExecuteAsync("LO_SP_EAN_I", dynamic, commandType: CommandType.StoredProcedure);
                }
            }
            finally
            {
                dynamic = null;
            }
            return entity;
        }
    }
}
