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
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly IDbConnection dbConnection;
        private bool disposedValue;

        public EstoqueRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public async Task<IEnumerable<Estoque>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Estoque> GetAsync(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Estoque>> SelectAsync(Estoque entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Estoque> CreateAsync(Estoque entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Estoque> UpdateAsync(Estoque entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Estoque> DeleteAsync(int code, int user)
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

        public async Task<ListEstoque> CreateEstoqueAsync(ListEstoque entity)
        {
            var dynamic = new DynamicParameters();
            try
            {
                foreach (var item in entity.estoque)
                {
                    dynamic.Add("QUANTIDADE", item.quantidade);
                    dynamic.Add("PRECO", item.preco);
                    dynamic.Add("EAN", item.ean);
                    dynamic.Add("ID_LOJA", item.idLoja);
                    dynamic.Add("ID_ENDERECO", item.idEndereco);


                    var result = await dbConnection.ExecuteAsync("LO_SP_ESTOQUE_I", dynamic, commandType: CommandType.StoredProcedure);
                }
            }
            finally
            {
                dynamic = null;
            }
            return entity;
        }

        public async Task<ConsultaEstoque> GetEstoqueAsync(int idLoja, int? cdProduto, int? cdEndereco)
        {
            var dynamic = new DynamicParameters();
            var resultado = string.Empty;
            ConsultaEstoque listagemItensRoot = new ConsultaEstoque();
                    
                    dynamic.Add("ID_LOJA", idLoja);
                    dynamic.Add("CD_PRODUTO", cdProduto);
                   
                    var result = await dbConnection.QueryAsync<string>("LO_SP_ESTOQUE_S", dynamic, commandType: CommandType.StoredProcedure);
                    
                    if (result != null)
                    {
                        if (result.Count() > 1)
                        {
                            for (int i = 0; i < result.Count(); i++)
                            {
                                resultado += result.ToArray()[i];
                            }
                        }
                        else
                        {
                            resultado = result.FirstOrDefault();
                        }

                        listagemItensRoot = JsonConvert.DeserializeObject<ConsultaEstoque>(resultado);
                    }
                    else
                    {
                        throw new Exception("Não foram encontrados registros!");
                    }

                    return listagemItensRoot;

        }
    }
}