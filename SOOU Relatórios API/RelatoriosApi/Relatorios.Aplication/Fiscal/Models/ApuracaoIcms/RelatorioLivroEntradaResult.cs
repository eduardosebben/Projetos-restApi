using Relatorios.Dominio.Entities.Entities;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Relatorios.Aplication.Fiscal.Models.ApuracaoIcms
{
    public class RelatorioApuracaoIcmsResult
    {
        public List<ItemApuracaoIcmsResult> Itens { get; set; } = new List<ItemApuracaoIcmsResult>();
        public ItemApuracaoIcmsResult TotalGeral { get; set; } = new ItemApuracaoIcmsResult();
        public ItemApuracaoIcmsResult TotalDentroEstado { get; set; } = new ItemApuracaoIcmsResult();
        public ItemApuracaoIcmsResult TotalExterior { get; set; } = new ItemApuracaoIcmsResult();
        public ItemApuracaoIcmsResult TotalForaEstado { get; set; } = new ItemApuracaoIcmsResult();


        public RelatorioApuracaoIcmsResult()
        {
            
        }

    }

    public class RelatorioApuracaoIcmsEntradasSaidasResult
    {
        public RelatorioApuracaoIcmsEntradasSaidasResult(RelatorioApuracaoIcmsResult entradas, RelatorioApuracaoIcmsResult saidas)
        {
            Entradas = entradas;
            Saidas = saidas;
        }

        public RelatorioApuracaoIcmsResult Entradas { get; set; } = new RelatorioApuracaoIcmsResult();
        public RelatorioApuracaoIcmsResult Saidas { get; set; } = new RelatorioApuracaoIcmsResult();
    }
}
