using Relatorios.Aplication.EmpresasPadrao.Models;

namespace Relatorios.Aplication.Common.Repositories
{
    public interface IRepositorioEmpresasPadrao
    {
        Task<EmpresasPadraoCollection> EmpresasPadraoCollection(int codEmpresa);
    }

}
