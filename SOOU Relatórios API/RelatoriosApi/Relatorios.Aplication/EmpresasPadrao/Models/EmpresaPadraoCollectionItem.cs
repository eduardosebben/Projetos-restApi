using Relatorios.Dominio.Enums;

namespace Relatorios.Aplication.EmpresasPadrao.Models
{
    public class EmpresaPadraoCollectionItem
    {
        public EmpresaPadrao TipoEmpresa { get; set; }
        public int CodEmpresaPadrao { get; set; }

        public EmpresaPadraoCollectionItem(EmpresaPadrao tipoEmpresa, int codEmpresa)
        {
            TipoEmpresa = tipoEmpresa;
            CodEmpresaPadrao = codEmpresa;
        }
    }
}
