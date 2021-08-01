using Api_Fornecedor.Model;

namespace Api_Fornecedor.Repository.RepositoryImplementation
{
    public interface IEmpresaRepository
    {
        public Empresas FindById(long Id);
    }
}