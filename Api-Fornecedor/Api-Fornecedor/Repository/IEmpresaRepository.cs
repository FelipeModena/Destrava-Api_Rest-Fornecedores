using Api_Fornecedor.Model;

namespace Api_Fornecedor.Repository.RepositoryImplementation
{
    public interface IEmpresaRepository
    {
        public Empresas FindByCnpj(string Id);
        Empresas Create(Empresas empresa);
    }
}