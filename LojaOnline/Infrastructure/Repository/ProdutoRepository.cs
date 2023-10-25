using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public ProdutoRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<Produto>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Produto> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produto>> SelectAsync(Produto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Produto> CreateAsync(Produto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Produto> UpdateAsync(Produto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Produto> DeleteAsync(int code, int user)
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

        public async Task<ListProduto> CreateProdutoAsync(ListProduto entity)
        {
            var dynamic = new DynamicParameters();
            
            try 
            {
                foreach (var item in entity.produtos)
                {
                    dynamic.Add("CD_PRODUTO", item.cd_produto);
                    dynamic.Add("ID_CATEGORIA01", item.id_categoria01);
                    dynamic.Add("ID_CATEGORIA02", item.id_categoria02);
                    dynamic.Add("@NOME", item.nome);
                    dynamic.Add("DESCRICAO", item.descricao);
                    dynamic.Add("ATIVO", item.ativo);

                    var result = await dbConnection.ExecuteAsync("LO_SP_PRODUTO_I", dynamic, commandType: CommandType.StoredProcedure);
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
