using Api_Fornecedor.BusinessImplementation;
using Api_Fornecedor.Model;
using Api_Fornecedor.Repository;
using ApiRestComASPNet.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Fornecedor.Business.BusinessImplementation
{
    public class FornecedorBusiness : IFornecedorBusiness
    {
        private readonly IGenericRepository<Fornecedor> _genericRepository;
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorBusiness(IGenericRepository<Fornecedor> genericRepository, IFornecedorRepository fornecedorRepository = null)
        {
            _genericRepository = genericRepository;
            _fornecedorRepository = fornecedorRepository;
        }

        public Fornecedor Create(Fornecedor fornecedor)
        {
           return _genericRepository.Create(fornecedor);
        }

        public void Delete(long id)
        {
             _genericRepository.Delete(id);
        }

        public Fornecedor FindByCnpj(string cnpj)
        {
            return _fornecedorRepository.GetByCnpj(cnpj);
        }


        public Fornecedor Update(Fornecedor fornecedor)
        {

            return _fornecedorRepository.Update(fornecedor) ;
        }


    }
}
