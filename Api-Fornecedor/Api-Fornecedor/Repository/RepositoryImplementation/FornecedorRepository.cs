using Api_Fornecedor.Model;
using ApiRestComASPNet.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Fornecedor.Repository.RepositoryImplementation
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly MySqlContext _sqlContext;

        public FornecedorRepository(MySqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public Fornecedor GetByCnpj(string cnpj)
        {
            return _sqlContext.Fornecedor.FirstOrDefault(f => f.Cnpj == cnpj);
        }

        public Fornecedor Update(Fornecedor fornecedor)
        {
            try
            {
                Fornecedor fornecedorDb = _sqlContext.Fornecedor.FirstOrDefault(f => f.Id == fornecedor.Id);
                _sqlContext.Entry(fornecedorDb).CurrentValues.SetValues(fornecedor);
                _sqlContext.Entry(fornecedorDb).Property(f => f.Cnpj).IsModified = false; // restricao 2.cnjp
                _sqlContext.Entry(fornecedorDb).Property(f => f.Email).IsModified = false; // restricao 2.email
                _sqlContext.SaveChanges();
                return fornecedorDb;
            }
            catch (Exception e)
            {

                LogDesenvolvedor logDesenvolvedor = new LogDesenvolvedor
                {
                    DateTime = DateTime.Now,
                    Error = e.Message,
                };
                _sqlContext.LogDesenvolvedor.Add(logDesenvolvedor);
                return null;
            }
        }
    }
}
