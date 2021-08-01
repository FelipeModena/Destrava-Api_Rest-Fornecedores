using Api_Fornecedor.Model;
using System.Collections.Generic;

namespace Api_Fornecedor.BusinessImplementation
{
    public interface IFornecedorBusiness
    {
        Fornecedor Create(Fornecedor fornecedor);
        Fornecedor Update(Fornecedor fornecedor);
        void Delete(long id);
        Fornecedor FindByCnpj(string cnpj);
    }
}