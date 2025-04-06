using Relatorios.Dominio.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Aplication.FaturamentoContratos.Models
{

    public class LANCAMENTOS_FATURAMENTO
    {
        public bool? TIP_ANALISADO { get; set; }
        public int? HMS_AJUSTADA { get; set; }
        public int? HMS_LANCAMENTO { get; set; }
        public int COD_LANCAMENTO { get; set; }
        public int COD_PRODUTO { get; set; }
        public string DES_PRODUTO { get; set; }
        public DateTime DTA_COBRANCA { get; set; }
        public bool? TIPO_COBRANCA_FATURAMENTO { get; set; }
        public int? IND_TIPO_LANCAMENTO { get; set; }
        public decimal? VLR_LANCAMENTO { get; set; }
        public decimal VLR_HORA { get; set; }
        public decimal VLR_HORA_PRECO_PRODUTO { get; set; }
        public decimal? VLR_DESCONTO { get; set; }
        public bool ehFaturado { get; internal set; }
        public bool TIP_CONSIDERAR_FRANQUIA { get; internal set; }
        public int? COD_PESSOA { get; private set; }
        public string? DES_PESSOA { get; private set; }
        public string? DES_RAZAO_SOCIAL { get; private set; }
        public int? COD_BANCO_PESSOA { get; set; }
        public List<DateTime> LISTA_VENCIMENTOS { get; set; } = new();
        public int? COD_TIPO_PAGAMENTO_PESSOA { get; set; }
        public string? DES_SOLICITANTE { get; private set; }
        public string? DES_OBSERVACAO { get; private set; }
        public List<string?> ListaObservacoesResolutivas { get; private set; }

        public LANCAMENTOS_FATURAMENTO()
        {

        }

        public static IQueryable<LANCAMENTOS_FATURAMENTO> QueryToModel(IQueryable<PS_LANCAMENTOS> query)
        {
            return query.OrderBy(x => x.DTA_COBRANCA).Select(l => new LANCAMENTOS_FATURAMENTO()
            {
                COD_PESSOA = l.COD_PESSOA,
                DES_PESSOA = l.COD_PESSOANavigation.DES_PESSOA,
                DES_RAZAO_SOCIAL = l.COD_PESSOANavigation.DES_RAZAO_SOCIAL,
                TIP_ANALISADO = l.TIP_ANALISADO,
                HMS_AJUSTADA = l.HMS_AJUSTADA,
                HMS_LANCAMENTO = l.HMS_LANCAMENTO,
                COD_LANCAMENTO = l.COD_LANCAMENTO,
                COD_PRODUTO = l.COD_PRODUTO,
                DES_PRODUTO = l.COD_PRODUTONavigation.DES_PRODUTO,

                DES_SOLICITANTE = l.DES_SOLICITANTE,
                DES_OBSERVACAO = l.DES_OBSERVACAO,
                ListaObservacoesResolutivas = l.PS_LANCAMENTOS_ITENS.Where(i => i.TIP_RESOLUTIVA == true).Select(i => i.DES_OBSERVACAO).ToList(),


                //public int? CodContrato { get; set; }
                //public int QtdFranquia { get; set; }
                //public int TipoContrato { get; set; }
                //public decimal VlrNaoConsiderarFaturamento { get; set; }


                DTA_COBRANCA = l.DTA_COBRANCA,
                TIPO_COBRANCA_FATURAMENTO = l.TIPO_COBRANCA_FATURAMENTO,
                IND_TIPO_LANCAMENTO = l.IND_TIPO_LANCAMENTO,
                VLR_LANCAMENTO = l.VLR_LANCAMENTO,
                VLR_HORA = l.VLR_HORA,
                VLR_HORA_PRECO_PRODUTO = l.COD_PRODUTONavigation.CE_PRODUTOS_VALORES.First().VLR_PRECO_VENDA,
                VLR_DESCONTO = l.VLR_DESCONTO,
                ehFaturado = l.FT_FATURA_ITENS.Any(x => (x.COD_FATURANavigation.TIP_EXCLUIDO ?? false) == false),
                TIP_CONSIDERAR_FRANQUIA = l.TIP_CONSIDERAR_FRANQUIA ?? false,
                COD_BANCO_PESSOA = l.COD_PESSOANavigation.COD_BANCO,
                LISTA_VENCIMENTOS = l.PS_LANCAMENTOS_VENCIMENTO.Select(v => v.DTA_VENCIMENTO).ToList(),
                COD_TIPO_PAGAMENTO_PESSOA = l.COD_PESSOANavigation.COD_TIPO_PAGAMENTO
            });
        }

    }

    public class CONTRATO
    {
        public int COD_PESSOA { get; set; }
        public DateTime? DTA_PROXIMA_FATURA_INICIAL { get; internal set; }
        public DateTime? DTA_PROXIMA_FATURA_FINAL { get; internal set; }
        public string NUM_CONTRATO { get; internal set; }
        public string DES_PESSOA { get; internal set; }
        public string DES_RAZAO_SOCIAL { get; internal set; }
        public int IND_RECORRENCIA { get; internal set; }
        public int NUM_DIA_EMISSAO { get; internal set; }
        public int IND_RECORRENCIA_FRANQUIA { get; internal set; }
        public DateTime? DTA_VIGENCIA_FINAL { get; internal set; }
        public DateTime? DTA_ULTIMA_FATURA { get; internal set; }
        public DateTime DTA_VIGENCIA_INICIAL { get; internal set; }
        public int? QTD_FRANQUIA { get; internal set; }
        public int? IND_TIPO_FRANQUIA { get; internal set; }

        public int COD_CONTRATO { get; internal set; }
        public bool? TIP_AGRUPA_FATURA_CONTRATO { get; internal set; }
        public int? COD_TIPO_PAGAMENTO { get; internal set; }
        public int? COD_TIPO_PAGAMENTO_PESSOA { get; internal set; }
        public int IND_REGRA_VENCIMENTO { get; internal set; }
        public int NUM_DIA_VENCIMENTO { get; internal set; }
        public int? COD_CONVENIO_BANCARIO { get; internal set; }
        public decimal VLR_HORA_SERVICO_PARAMETRO { get; internal set; }
        public decimal? VLR_CONTRATO { get; internal set; }
        public DateTime? DTA_ULTIMO_REAJUSTE { get; internal set; }
        public int? COD_BANCO_PESSOA { get; set; }
        public List<ITEM_CONTRATO> ITEMS { get; set; } = new List<ITEM_CONTRATO>();
        public int? IND_FIXADO { get; set; }
    }

    public class CONVENIO_BANCARIO_FATURAMENTO
    {
        public int CODIGO { get; set; }
        public string DESCRICAO { get; set; }

        public static IQueryable<CONVENIO_BANCARIO_FATURAMENTO> QueryToModel(IQueryable<CR_CONVENIOS_BANCARIOS> query)
        {
            return query.Select(x => new CONVENIO_BANCARIO_FATURAMENTO()
            {
                CODIGO = x.COD_CONVENIO_BANCARIO,
                DESCRICAO = x.DES_CONVENIO,
            });
        }

    }

    public class BANCO_FATURAMENTO
    {
        public int CodBanco { get; set; }
        public string? DesBanco { get; set; }
        public List<int> LISTA_CONVENIOS_RELACIONADOS { get; set; }

        public static IQueryable<BANCO_FATURAMENTO> MapToModel(IQueryable<GE_BANCOS> query)
        {
            return query.Select(x => new BANCO_FATURAMENTO()
            {
                CodBanco = x.COD_BANCO,
                DesBanco = x.DES_BANCO,
                LISTA_CONVENIOS_RELACIONADOS = x.COD_BANCO_HOMOLOGADONavigation.CR_CONTAS_BANCARIAS
                    .SelectMany(cb => cb.CR_CONVENIOS_BANCARIOS.Select(c => c.COD_CONVENIO_BANCARIO))
                    .ToList()
            });
        }
    }

    public class TIPO_PAGAMENTO_FATURAMENTO
    {
        public int CODIGO { get; set; }
        public string? DESCRICAO { get; set; }

        public static IQueryable<TIPO_PAGAMENTO_FATURAMENTO> MapToModel(IQueryable<GE_TIPO_PAGAMENTO> query)
        {
            return query.Select(x => new TIPO_PAGAMENTO_FATURAMENTO()
            {
                CODIGO = x.COD_TIPO_PAGAMENTO,
                DESCRICAO = x.DES_TIPO_PAGAMENTO,
            });
        }

    }

    public class ITEM_CONTRATO
    {
        public int COD_PRODUTO { get; internal set; }
        public int? IND_TIPO_CONTRATO { get; internal set; }
        public int? QTD_FRANQUIA { get; internal set; }
        public int COD_CONTRATO_ITENS { get; internal set; }
        public decimal? VLR_CONTRATO { get; internal set; }
        public string? DES_SERVICO_NOTA { get; internal set; }
        public string? DES_PRODUTO { get; internal set; }
    }
}
