using Api_Fornecedor.Model;
using ApiRestComASPNet.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Fornecedor.Repository.RepositoryImplementation
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly MySqlContext _sqlContext;

        public EmpresaRepository(MySqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public Empresas Create(Empresas empresa)
        {
            try
            {
                Empresas emp = _sqlContext.Empresas.FirstOrDefault(e => e.Cnpj == empresa.Cnpj);
                if (emp == null)
                {
                    _sqlContext.Empresas.Add(empresa);
                    if (empresa.Fornecedores.Count() > 0)
                    {
                        foreach (var fornecedor in empresa.Fornecedores)
                        {
                            if (_sqlContext.Fornecedor.FirstOrDefault(f => f.Cnpj == fornecedor.Cnpj) != null)
                            {
                                _sqlContext.Fornecedor.Add(fornecedor);
                            }
                        }
                    }
                    _sqlContext.SaveChanges();
                    return empresa;
                }
                else
                {
                    return null;
                }
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

        public Empresas FindByCnpj(string cnpj)
        {
            try
            {
                Empresas empresa = _sqlContext.Empresas.Include(f => f.Fornecedores).FirstOrDefault(e => e.Cnpj == cnpj);
                return empresa;

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
