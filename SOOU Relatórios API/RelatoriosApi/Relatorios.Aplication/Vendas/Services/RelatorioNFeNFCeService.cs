using Microsoft.EntityFrameworkCore;
using Relatorios.Aplication.Common.Estruturas;
using Relatorios.Aplication.Common.Repositories;
using Relatorios.Aplication.Inventario.Models;
using Relatorios.Aplication.Vendas.Models;
using Relatorios.Dominio.Entities.Entities;
using Relatorios.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Aplication.Vendas.Services
{
    public interface IServicoRelatorioNFeNFCe
    {
        Task<Result<List<RelatorioNFeNFCeNotaResponse>, Error>> RelatorioNFeNFCe(FiltroRelatorioNFe model);
    }

    public class RelatorioNFeNFCeService : IServicoRelatorioNFeNFCe
    {
        private readonly IErpRepositorioGenerico _erpRepositorioGenerico;

        public RelatorioNFeNFCeService(IErpRepositorioGenerico erpRepositorioGenerico)
        {
            _erpRepositorioGenerico = erpRepositorioGenerico;
        }

        public async Task<Result<List<RelatorioNFeNFCeNotaResponse>,Error>> RelatorioNFeNFCe(FiltroRelatorioNFe filtro)
        {
            var queryNotas = _erpRepositorioGenerico.Query<FT_NOTAS>();

            queryNotas = PesquisarRelatorioNotas(queryNotas, filtro);

            var resultado = RelatorioNFeNFCeNotaResponse.QueryToRelatorioNFeNFCeNotaResponse(queryNotas);

            return resultado;
        }

        private IQueryable<FT_NOTAS> PesquisarRelatorioNotas(IQueryable<FT_NOTAS> query ,FiltroRelatorioNFe filtro)
        {
            query = query.Where(x => x.COD_EMPRESA == filtro.codEmpresa);
            if (filtro.listaModelos != null && filtro.listaModelos.Any())
            {
                var tipoNotasMapeadas = new List<int>();
                filtro.listaModelos.ToList().ForEach(x =>
                {
                    switch (x)
                    {
                        case (TipoNotaFiscal)TipoModeloNotaFiscal.NFe:
                            tipoNotasMapeadas.Add((int)TipoNotaFiscal.NFe);
                            break;
                        case (TipoNotaFiscal)TipoModeloNotaFiscal.NFCe:
                            tipoNotasMapeadas.Add((int)TipoNotaFiscal.NFCe);
                            break;
                        case TipoNotaFiscal.NFSe:
                            tipoNotasMapeadas.Add((int)TipoNotaFiscal.NFSe);
                            break;
                    }
                });

                query = query.Where(x => tipoNotasMapeadas.Contains(x.IND_TIPO_NOTA ?? 0));
            }

            if (filtro.dtaEmissaoInicial.HasValue)
            {
                query = query.Where(x => x.DTA_EMISSAO >= filtro.dtaEmissaoInicial.Value.Date);
            }
            
            if (filtro.dtaEmissaoFinal.HasValue)
            {
                var dta = filtro.dtaEmissaoFinal.Value.AddDays(1).Date;
                query = query.Where(x => x.DTA_EMISSAO < dta);
            }
            
            if (filtro.dtaAutorizacaoInicial.HasValue)
            {
                query = query.Where(x => x.DTA_AUTORIZACAO >= filtro.dtaAutorizacaoInicial);
            }

            if (filtro.dtaAutorizacaoFinal.HasValue)
            {
                var dta = filtro.dtaAutorizacaoFinal.Value.AddDays(1).Date;
                query = query.Where(x => x.DTA_AUTORIZACAO < dta);
            }

            if (!string.IsNullOrEmpty(filtro.desSerie))
                query = query.Where(x => x.DES_SERIE == filtro.desSerie);

            if (filtro.codCliente.HasValue && filtro.codCliente != 0)
                query = query.Where(x => x.COD_PESSOA == filtro.codCliente);

            if (filtro.Representantes.Any())
                query = query.Where(x =>
                    x.FT_NOTAS_REPRESENTANTES.Any(y => filtro.Representantes.Any(c => c == y.COD_PESSOA)));

            if (filtro.numNotaInicial.HasValue && filtro.numNotaInicial != 0)
                query = query.Where(x => x.NUM_NOTA >= filtro.numNotaInicial);

            if (filtro.numNotaFinal.HasValue && filtro.numNotaFinal != 0)
                query = query.Where(x => x.NUM_NOTA <= filtro.numNotaFinal);

            if (filtro.listaStatus != null && filtro.listaStatus.Any())
                query = query.Where(x => filtro.listaStatus.Contains((TipoSituacaoNota)x.IND_SITUACAO));

            if (filtro.apenasVendas)
                query = query.Where(x => x.COD_OPERACAO_FISCALNavigation.TIP_NAO_CONSIDERAR_RELATORIO_VENDAS != filtro.apenasVendas);

            return query;
        }

    }

}
