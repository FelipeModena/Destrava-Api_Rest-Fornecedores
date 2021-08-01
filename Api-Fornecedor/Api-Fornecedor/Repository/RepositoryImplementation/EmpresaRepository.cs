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

        public Empresas FindById(long id)
        {
            Empresas empresa = _sqlContext.Empresas.FirstOrDefault(e=>e.Id==id);
            return new Empresas{ };
        }
    }
}
