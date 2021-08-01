using Api_Fornecedor.Model;

namespace Api_Fornecedor.Repository
{
    public interface IFornecedorRepository
    {
        public Fornecedor Update(Fornecedor fornecedor);
        public Fornecedor GetByCnpj(string cnpj);
    }
}