using Relatorios.Dominio.Entities.Entities;

namespace Relatorios.Aplication.EvolucaoCompras.Models
{
    public class EvolucaoComraRelatorioResponse
    {
        public List<EvolucaoCompraResponse> Itens { get; set; } = new();
        public EvolucaoCompraResponse Total => new EvolucaoCompraResponse()
        {
            Quantidade = Itens.Sum(x => x.Quantidade),
            Valor = Itens.Sum(x => x.Valor)
        };


        public EvolucaoComraRelatorioResponse()
        {
        }

    }

    public class EvolucaoCompraResponse
    {
        public DateTime Data { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
    }

    public class EvolucaoCompraResponseMapper
    {
        public static IQueryable<EvolucaoCompraResponse> MapTo(IQueryable<CE_NOTAS_ITENS> query)
        {
            return query
               .GroupBy(i => new { i.COD_NOTANavigation.DTA_EMISSAO.Value.Month, i.COD_NOTANavigation.DTA_EMISSAO.Value.Year })
               .Select(g => new EvolucaoCompraResponse()
               {
                   Data = new DateTime(g.Key.Year, g.Key.Month, 1),
                   Quantidade = g.Sum(i => i.QTD_PRODUTO ?? 0),
                   Valor = g.Sum(i => i.VLR_TOTAL ?? 0)
               });
        }

        public static IQueryable<EvolucaoCompraResponse> MapTo(IQueryable<FT_NOTAS_ITENS> query)
        {
            return query
               .GroupBy(i => new { i.COD_NOTANavigation.DTA_EMISSAO.Month, i.COD_NOTANavigation.DTA_EMISSAO.Year })
               .Select(g => new EvolucaoCompraResponse()
               {
                   Data = new DateTime(g.Key.Year, g.Key.Month, 1),
                   Quantidade = g.Sum(i => i.QTD_PRODUTO ?? 0),
                   Valor = g.Sum(i => i.VLR_TOTAL ?? 0)
               });
        }
    }


}
