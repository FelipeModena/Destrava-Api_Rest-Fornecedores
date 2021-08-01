using Api_Empresas.Business.BusinessImplementation;
using Api_Fornecedor.Model;
using Api_Fornecedor.Repository.RepositoryImplementation;
using ApiRestComASPNet.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Fornecedor.Business.BusinessImplementation
{
    public class EmpresaBusiness : IEmpresaBusiness
    {
        private readonly IGenericRepository<Empresas> _genericRepository;
        private readonly IEmpresaRepository _empresaRepository;
        public EmpresaBusiness(IGenericRepository<Empresas> genericRepository, IEmpresaRepository empresaRepository = null)
        {
            _genericRepository = genericRepository;
            _empresaRepository = empresaRepository;
        }

        public Empresas Create(Empresas empresa)
        {
            return _empresaRepository.Create(empresa);
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Empresas FindByCnpj(string id)
        {
            return _empresaRepository.FindByCnpj(id);
        }

        public Empresas Update(Empresas empresa)
        {
            throw new NotImplementedException();
        }
    }
}
