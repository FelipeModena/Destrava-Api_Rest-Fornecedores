using Api_Fornecedor.Model;

namespace Api_Empresas.Business.BusinessImplementation
{
    public interface IEmpresaBusiness
    {
        Empresas Create(Empresas empresa);
        Empresas FindById(long id);
        Empresas Update(Empresas empresa);
        void Delete(long id);
    }
}