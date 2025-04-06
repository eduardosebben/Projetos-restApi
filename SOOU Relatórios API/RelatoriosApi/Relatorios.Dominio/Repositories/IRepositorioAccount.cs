using SoouCommon.Enum;

namespace Relatorios.Dominio.Repositories
{
    public interface IRepositorioAccount
    {
        Task<string?> RetornarStringConnection(string guidOrganizacao, TipoAmbiente tipoAmbiente);
        Task<bool> ValidarTokenDistribuidoOrganizacao(string guidOrg, string token);
    }


}
